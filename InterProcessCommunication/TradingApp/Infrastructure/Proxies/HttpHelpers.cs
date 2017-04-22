using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Proxies
{
    public static class HttpHelpers
    {
        public static HttpClient CreateNewClient<T>()
        {
            string address = GetAddress<T>();
            var client = new HttpClient();
            client.BaseAddress=new Uri(address);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static string GetAddress<T>()
        {
            string settingKey = $"{typeof(T).Name}_Address";
            return ConfigurationManager.AppSettings[settingKey];
        }
    }
}