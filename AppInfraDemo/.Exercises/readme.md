# This file contains exercises based on the AppInfra demo

## 1. Notification Service

#### 1.1 Module notification

Add a `NotificationsModule : IModule` and notify when it is alive.

As a model for this, look on how `SaleServicesModule` is implemented and how its *I'm Alive* notification is shown in the `ConsoleApplication`.

#### 1.2. Create a composite for `NotificationService.NotifyAlive()`

Current implementation of `NotifyAlive()` first tries to get the unlabeled `IAmAliveSubscriber<T>` implementation and then it get all labeled implementation.
	
This try/catch is ugly and could be avoided w/ a composite `IAmAliveSubscriber` which gets all labeled `IAmAliveSubscriber` and forwards the call to them
 
 **Solution** see branch `ex/NotificationServiceComposite`


#### 1.3. OrderStateChangeSubscriber that writes in a text file
  
 Write a subscriber that writes in a text file when a new SalesOrder is created, deleted or changed

#### 1.4. OrderStateChangeSubscriber for the UI
 
 Write a subscriber that shows on the UI when a new SalesOrder is created, deleted or changed

------------------

## 2. Console Application


### 2.1. Transform the OrdersConsoleApplication into an IModule
	
Make this class to implement the `IModule`. 
The `Program.Main()` should not to depend directly on it. On `IModule.Init()` the menu should be shown


### 2.2. Transform the OrdersConsoleApplication IModule in a generic console UI

Create the `IConsoleCommand` interface as below:

```
public interface ICommand
{
    void Execute();
    string MenuEntry { get; }
}
```

The `ColsoleUiModule` would discover all the `IConsoleCommand` implementations, and will build a menu with them on its `Init()` function.

This should allow any module to implement commands, which are low coupled, and the `ConsoleUiModule` will discover them and will present them to the user for execution.

### 2.3. Unit Test the ShowAllOrders

Write some unit tests for the `OrdersConsoleApplication.ShowAllOrders()` function

-----------------------------


## 3. Ordering Service

### 3.1 Create an operation that returns all the customers which have orders, ordered by name

- Write unit tests for this. There should be tests that verify if there order by is applied.
- Show only the customers that have the name starting with a character which was read from the console.

### 3.2 Add Persons Management Module

`SalesPerson` references through `BusinessEntityID` a `Person` from Person schema.

Create a new module named `Persons` which exposes a service that gives all the persons. This service should be used by `GetOrdersInfo()` to return the person name in the `SalesOrderInfo` result.

As an alternative, the service from the `Persons` module could be used by the UI and `GetOrdersInfo()` just returns the `BusinessEntityID` key

## 4. Add a new `Person`

### 4.1 Create support to read a entity from the console

Use the following interfaces:

```
interface IEntityReader
{
    IEntityFieldsReader<T> BeginEntityRead<T>();
}

interface IEntityFieldsReader<T>
{
    IEnumerable<string> GetFields();
    void SetFieldValue(string value);
    T GetEntity();
}
```

Read a the data needed to create a `Person` entity

### 4.2. Create a service that adds a new `Person` to the system

The above console command which reads the person info should use this service to add the new read person.