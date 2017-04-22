using System.Net.Http;
using System.Web;
using Contracts.Portfolio.Services;
using Contracts.Quotations.Services;
using iQuarc.AppBoot;

namespace Proxies
{
    [Service(typeof(IPortfolioService))]
    class PortfolioServiceProxy : IPortfolioService
    {
        public decimal GetPortfolioValue()
        {
            using (HttpClient client = HttpHelpers.CreateNewClient<IPortfolioService>())
            {
                string path = HttpHelpers.GetServicePath<IPortfolioService>("GetValue");
                HttpResponseMessage response = client.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    decimal value = response.Content.ReadAsAsync<decimal>().Result;
                    return value;
                }

                throw new HttpException((int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
