using System.Net.Http;
using System.Web;
using AppBootEx;
using Contracts.Portfolio.Services;

namespace Proxies
{
    [ServiceProxy(typeof(IPortfolioService))]
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
