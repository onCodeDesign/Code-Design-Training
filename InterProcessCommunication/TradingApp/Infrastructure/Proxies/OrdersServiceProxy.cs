using System;
using System.Net.Http;
using System.Web;
using Contracts.Sales.Services;
using iQuarc.AppBoot;

namespace Proxies
{
    [Service(typeof(IOrdersService))]
    class OrdersServiceProxy : IOrdersService
    {
        public void PlaceSellLimitOrder(string securityCode, decimal sellingPrice, DateTime validUntil)
        {
            using (HttpClient client = HttpHelpers.CreateNewClient<IOrdersService>())
            {
                string path = HttpHelpers.GetServicePath<IOrdersService>("PlaceSellLimitOrder");
                string uri = $"{path}?securityCode={securityCode}&sellingPrice={sellingPrice}&validUntil={validUntil}";
                HttpResponseMessage response = client.PostAsync(uri, new StringContent(string.Empty)).Result;
                if (!response.IsSuccessStatusCode)
                    throw new HttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
            }
        }

        public void PlaceBuyLimitOrder(string securityCode, decimal buyingPrice, DateTime validUntil)
        {
            using (HttpClient client = HttpHelpers.CreateNewClient<IOrdersService>())
            {
                string path = HttpHelpers.GetServicePath<IOrdersService>("PlaceBuyLimitOrder");
                string uri = $"{path}?securityCode={securityCode}&buyingPrice={buyingPrice}&validUntil={validUntil}";
                HttpResponseMessage response = client.PostAsync(uri, new StringContent(string.Empty)).Result;
                if (!response.IsSuccessStatusCode)
                    throw new HttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
            }
        }

        public LimitOrder[] GetLimitOrders()
        {
            using (HttpClient client = HttpHelpers.CreateNewClient<IOrdersService>())
            {
                string path = HttpHelpers.GetServicePath<IOrdersService>("GetLimitOrders");
                HttpResponseMessage response = client.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    LimitOrder[] value = response.Content.ReadAsAsync<LimitOrder[]>().Result;
                    return value;
                }

                throw new HttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}