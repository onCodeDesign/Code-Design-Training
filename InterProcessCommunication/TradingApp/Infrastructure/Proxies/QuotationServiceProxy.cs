using System;
using System.Net.Http;
using System.Web;
using AppBootEx;
using Contracts.Portfolio.Services;
using Contracts.Quotations.Services;
using iQuarc.AppBoot;

namespace Proxies
{
    [ServiceProxy(typeof(IQuotationService))]
    class QuotationServiceProxy : IQuotationService
    {
        public Quotation[] GetQuotations(string exchange, string instrument, DateTime @from, DateTime to)
        {
            using (HttpClient client = HttpHelpers.CreateNewClient<IQuotationService>())
            {
                string path = HttpHelpers.GetServicePath<IQuotationService>("GetByExchange");
                string uri = $"{path}?exchange={exchange}&instrument={instrument}&from={from}&to={to}";
                HttpResponseMessage response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    Quotation[] value = response.Content.ReadAsAsync<Quotation[]>().Result;
                    return value;
                }

                throw new HttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
            }
        }

        public Quotation[] GetQuotations(string securityCode, DateTime from, DateTime to)
        {
            using (HttpClient client = HttpHelpers.CreateNewClient<IQuotationService>())
            {
                string path = HttpHelpers.GetServicePath<IQuotationService>("GetBySecurity");
                string uri = $"{path}?securityCode={securityCode}&from={from:yyyy-MM-dd}&to={to:yyyy-MM-dd}";
                HttpResponseMessage response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    Quotation[] value = response.Content.ReadAsAsync<Quotation[]>().Result;
                    return value;
                }

                throw new HttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
            }
        }

        public Quotation[] GetQuotations(string[] securities, DateTime from, DateTime to)
        {
            using (HttpClient client = HttpHelpers.CreateNewClient<IQuotationService>())
            {
                string path = HttpHelpers.GetServicePath<IQuotationService>("GetBySecurities");
                var queryString = HttpUtility.ParseQueryString(string.Empty);
                for (int i = 0; i < securities.Length; i++)
                {
                    queryString.Add("securities", securities[i]);
                }
                queryString["from"] = @from.ToString("yyyy-MM-dd");
                queryString["to"] = to.ToString("yyyy-MM-dd");


                HttpResponseMessage response = client.GetAsync($"{path}?{queryString}").Result;
                if (response.IsSuccessStatusCode)
                {
                    Quotation[] value = response.Content.ReadAsAsync<Quotation[]>().Result;
                    return value;
                }

                throw new HttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
            }
        }   
    }
}