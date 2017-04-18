Presentation Script
================


#### 0.	Preset VS solution. It has:

 - Infrastructure & Modules
 - Projects for modules and host
  
**Points:**
-	In Contracts only  interfaces and DTOs. No logic
-	No references between Module assemblies
    -   these are OperationContracts, DataContracts, FaultContracts


#### 1.	Create (code) the `IQuotationService` in `Contracts`

**Points:**
-	It’s an *System Contract* (any subsytem can use it)
-   Will be implemented by QuotationModule and used by other modules
-   Has to have only DTOs which can be serialized w/ many serializers (prefere array rather than abstract types)

#### 2. Implement the `QuotationService` in `QuotationModule`

```
class QuotationService : IQuotationService
    {
        private readonly Quotation[] array = 
            {
                new Quotation {AskPrice = 10.50m, BidPrice = 10.55m, SecurityCode = "ING.S.NYSE"},
                new Quotation {AskPrice = 12.50m, BidPrice = 12.55m, SecurityCode = "ING.B.NYSE"},
                new Quotation {AskPrice = 10.70m, BidPrice = 10.75m, SecurityCode = "AAPL.B.NASDAQ"},
                new Quotation {AskPrice = 11.50m, BidPrice = 11.55m, SecurityCode = "AAPL.S.NASDAQ"},
                new Quotation {AskPrice = 16.50m, BidPrice = 16.55m, SecurityCode = "MSFT.B.NASDAQ"},
                new Quotation {AskPrice = 17.50m, BidPrice = 17.55m, SecurityCode = "ING.B.AEX"},
                new Quotation {AskPrice = 10.51m, BidPrice = 10.59m, SecurityCode = "ING.S.AEX"},
            };
        
        public Quotation[] GetQuotations(string exchange, string instrument, DateTime @from, DateTime to)
        {
            var result = array.Where(q => q.SecurityCode.Contains(exchange));

            if (!string.IsNullOrWhiteSpace(instrument))
                result = result.Where(q => q.SecurityCode.Contains(instrument));

            return result.ToArray();
        }

        public Quotation[] GetQuotations(string securityCode, DateTime @from, DateTime to)
        {
            return array.Where(q => q.SecurityCode == securityCode).ToArray();
        }
    }
```

#### 3. Implement `OrderingService` in `SalesModule`


**Points:**
- Depends on the **contract** of the QuotationService NOT on the implementation
- No references among the modules. Look at the *Project Dependency Diagram*
- We need a way to link things at runtime

#### 4. Implement `PortfolioService` in `PortfolioModule`

**Points:**
- Depends on the **contract** of the QuotationService NOT on the implementation
- Its contract is also part of the `Contracts` assembly because it will be called from the UI, which will be hosted in a different process.
    - the point of this demo is not necessarely the communication between BE and FE, which might be done differently from the communication between BE components. 
    - however in most cases it is done in the same way, therefore it makes sens to add it in contracts.
