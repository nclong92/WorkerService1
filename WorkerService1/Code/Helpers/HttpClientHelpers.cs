using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.Code;

namespace WorkerService2.Code.Helpers
{
    public class HttpClientHelpers
    {
        public static async Task<string> GetHttpClientHelper(string uriString)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uriString);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.ConnectionClose = false;
                client.Timeout = TimeSpan.FromMinutes(5);
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(string.Empty),
                                                                Encoding.UTF8,
                                                                "application/json");

                    var requestUri = uriString;

                    var response = await client.GetAsync(requestUri);

                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync();

                    return result;
                }
                catch (Exception ex)
                {
                    
                }
            }

            return null;
        }
    }
}
