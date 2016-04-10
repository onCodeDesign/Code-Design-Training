# This file contains exercises based on the AppInfra demo

## 1. Ordering Service

### 1.1 Add Persons Management Module

`SalesPerson` references through `BusinessEntityID` a `Person` from Person schema.

Create a new module named `Persons` which exposes a service that gives all the persons. This service should be used by `GetOrdersInfo()` to return the person name in the `SalesOrderInfo` result

As an alternative, the service from the `Persons` module could be used by the UI and GetOrdersInfo() just returns the BusinessEntityID key


## 2. Console Application

### 2.1. Create a static wrapper for `IConsole` that facilitates its usage

Make an static caller to it that uses `ServiceLocator` to wrapp the `IConsole` instance


### 2.2. `IConsole` through static caller


Suposing we would have `IConsole` indentical w/ the public interface of `Console` static class. 

- Why would we abstract the existent static `Console` class through `IConsole`?
- Why would we make an static caller to it that uses `ServiceLocator` to wrapp the `IConsole` instance


### 2.3. Unit Test the ShowAllOrders

Write some unit tests for the `OrdersConsoleApplication.ShowAllOrders()` function


