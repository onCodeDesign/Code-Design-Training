using System.Web.Http;
using Contracts.Portfolio.Services;

namespace ConsoleHost.Controllers
{
    public class PortfolioController : ApiController
    {
        private readonly IPortfolioService portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            this.portfolioService = portfolioService;
        }

        public decimal GetValue()
        {
            return portfolioService.GetPortfolioValue();
        }
    }
}