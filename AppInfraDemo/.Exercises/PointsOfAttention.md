# Enforce Data Access Layer and Business Logic Layer separation

- No assembly except the `*.DataAccess` ones are allowed to reference the `Entity Framework`

- By default the EF generates the DTOs in the same project w/ the `DbContext`. This does not enforce the separation.

- We should change the generator to put in the `DataAccess` the `DbContext` needed for implementing the `Repository` and `UnitOfWork` and in the Sales Module the DTOs as they are its Data Model

- The tag `Infra_DataAccessDependsOnSales` shows a first step on doing this.
    - however, here there is "wrong" reference from the `DataAccess` to the Sales Modules assembly

- The tag `Infra_DataAccessDependencyOnSalesRemoved` shows how this reference is inverted by using the `IDbContextFactory` abstraction
