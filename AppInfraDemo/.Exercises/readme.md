# This file contains exercises based on the AppInfra demo

## 1. Notification Service

## 1.1 Module notification

Add a Notifications IModule and notify when it is alive.

As a model for this look on how SaleServicesModule is implementated on how its *I'm Alive* notification is shown in the ConsoleApplication. 
Implement the same for a Notifications Module

## 1.2. Create a composite for `NotificationService.NotifyAlive()`

Current implementation of `NotifyAlive()` first tryies to get the unlabeled `IAmAliveSubscriber<T>` implementation and then it get all labeled implementaion.
	This try/cath is ugly and could be avoided w/ a composite IAmAliveSubscriber which get all labele IAmAliveSubscriber and forwards the call to them
	
	**Solution** see branch ex/NotificationServiceComposite

## 1.3. OrderStateChangeSubscriber that writes in a text file
  
 Write a subsriber that writes in a test file when a new SalesOrder is created, deleted or changed

## 1.4. OrderStateChangeSubscriber for the UI
 
 Write a subscriber that shows on the UI when a new SalesOrder is created, deleted or changed

------------------

## 2. Console Application

### 2.1. Create a static wrapper for `IConsole` that facilitates its usage

Make an static caller to it that uses `ServiceLocator` to wrapp the `IConsole` instance


### 2.2. `IConsole` through static caller


Suposing we would have `IConsole` indentical w/ the public interface of `Console` static class. 

- Why would we abstract the existent static `Console` class through `IConsole`?
- Why would we make an static caller to it that uses `ServiceLocator` to wrapp the `IConsole` instance


### 2.3. Transform the OrdersConsoleApplication int an IModule
	
	Make this app implement the `IModule`. The `Program.Main()` not to depend on directly on it. On `IModule.Init()` the menu should be shown


### 2.4. Unit Test the ShowAllOrders

Write some unit tests for the `OrdersConsoleApplication.ShowAllOrders()` function


--------------------------


## 3. Ordering Service

### 3.1 Create an operation that returns all customers which have orders

### 3.2 Add Persons Management Module

`SalesPerson` references through `BusinessEntityID` a `Person` from Person schema.

Create a new module named `Persons` which exposes a service that gives all the persons. This service should be used by `GetOrdersInfo()` to return the person name in the `SalesOrderInfo` result

As an alternative, the service from the `Persons` module could be used by the UI and GetOrdersInfo() just returns the BusinessEntityID key


