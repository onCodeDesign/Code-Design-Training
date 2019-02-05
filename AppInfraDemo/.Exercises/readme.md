# This file contains exercises based on the AppInfra demo

## 1. Notification Service

#### 1.1 Module notification

Add a `NotificationsModule : IModule` and notify when it is alive.

As a model for this, look on how `SaleServicesModule` is implemented and how its *I'm Alive* notification is shown in the `ConsoleApplication`.

#### 1.2. Create a composite for `NotificationService.NotifyAlive()`

Current implementation of `NotifyAlive()` first tries to get the unlabeled `IAmAliveSubscriber<T>` implementation and then it get all labeled implementation.
	
This try/catch is ugly and could be avoided w/ a composite `IAmAliveSubscriber` which gets all labeled `IAmAliveSubscriber` and forwards the call to them
 
 **Solution** see branch `ex/NotificationServiceComposite`


#### 1.3. OrderStatusChangeSubscriber that writes in a text file
  
 Write a subscriber that writes in a text file when a new SalesOrder is created, deleted or changed

#### 1.4. OrderStatusChangeSubscriber for the UI
 
 Write a subscriber that shows on the UI when a new SalesOrder is created, deleted or changed

------------------

## 2. Console Application


### 2.1. Transform the OrdersConsoleApplication into an IModule
	
Make this class to implement the `IModule`. 
 - You should also consider to rename it, so its name reflects that it is a module

The `Program.Main()` should not to depend directly on it. On `IModule.Init()` the menu should be shown

### 2.2. Unit Test the `Init()` function of the resulted Module

Which is the external dependencies?
When do we use stubs and when mocks?


## 3. Create a Composite Console Application

### 3.1. Transform the OrdersConsoleApplication, in a module which is generic and a composite console UI

Create the `IConsoleCommand` interface as below:

```
public interface IConsoleCommand
{
    void Execute();
    string MenuLabel { get; }
}
```

The `ColsoleUiModule` would discover all the `IConsoleCommand` implementations, and will build a menu with them on its `Init()` function.

This should allow any module to implement commands, which are low coupled, and the `ConsoleUiModule` will discover them and will present them to the user for execution.

### 3.2. Update the solution structure in such way that each module may have its own `ConsoleModule`

Now, the `IModule` resulted from the previous `OrdersConsoleApplication` sits in the `ConsoleApplication`, but it is quite intimate with the `Sales` module
We could move it to a new console project into the `Sales` module folder structure, and the new `CompositeConsoleUiModule` should discover it and use it.

### 3.3. Order the Menu entries

a) in a declarative manner
b) by module and then by more entries in the same module

-----------------------------


## 4. Ordering Service

All below should be called through a simple UI like the Console UI built in previous exercises

### 4.1. Create an operation that returns all the customers which have orders, ordered by name

- Write unit tests for this. 
- There should be tests that verify if there order by is applied.

### 4.2. Add more filters

- Show only the customers that have the name starting with a string which was read from the console.
- Show only the customers that have in the name a string which was read from the console
- Write Unit Tests for the above

### 4.3. Create a console command that sets the status of all orders of a customer

 - We can hardcode the status that will be set OR read it from console
 - We should read some relevant info about the customer that we will use to find the orders to which we will change the status

!Observe how the interceptors created in exercises 1.3. and 1.4. are called when the update happens

## 5. Add Persons Management Module

### 5.1. Use Services from Persons Module in Sales Module

`SalesPerson` references through `BusinessEntityID` a `Person` from Person schema.

Create a new module named `Persons` which exposes a service that gives all the persons. This service should be used by `GetOrdersInfo()` to return the person name in the `SalesOrderInfo` result.

As an alternative, the service from the `Persons` module could be used by the UI and `GetOrdersInfo()` just returns the `BusinessEntityID` key

## 6 Add a new `Person`

### 6.1 Create support to read a entity from the console

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

### 6.1. Create a service that adds a new `Person` to the system

The above console command which reads the person info should use this service to add the new read person.

## 7. Add Audit to entity changes

### 7.1. We want to consistently set the `ModifiedDate` for all entities that have this column

 - Now when we modify the order in exercise 4.3 or we add persons in exercise 5 the `ModifiedDate` is not set.
 - One way would be to go in all use cases where these entities are modified / created and set the `ModifiedDate` as well. This would be cumbersome and error prone
 - We should leverage the advantage of the encapsulated Data Access and extend the infrastructure, with an interceptors that does this for all entities.

 The interface which should be implemented by the Data Model entities could look like:

```
interface IAuditable
{
    DateTime ModifiedDate {get;set;}
}
```