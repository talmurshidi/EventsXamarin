using EventsXamarin.Helpers;
using EventsXamarin.Models;

using Refit;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EventsXamarin.Rest
{
    public class ApiService
    {
        const string BaseUrl = "https://cat-fact.herokuapp.com";
        const int Timeout = 25;
        private readonly ICatAPI catAPI;

        public async Task<KeyValuePair<int, List<CatFactModel>>> CatFactsAsync()
        {
            try
            {
                var response = await catAPI.CatFactsAsync();
                var statusCode = (int)response.StatusCode;

                var stringContent = await response.Content.ReadAsStringAsync();

                var content = Utils.DeserializeObject<List<CatFactModel>>(stringContent);
                return new KeyValuePair<int, List<CatFactModel>>(statusCode, content);
            }
            catch (TaskCanceledException ex)
            {
                return new KeyValuePair<int, List<CatFactModel>>(408, default);
            }
            catch (TimeoutException ex)
            {
                return new KeyValuePair<int, List<CatFactModel>>(408, default);
            }
            catch (Exception ex)
            {
                return new KeyValuePair<int, List<CatFactModel>>(500, default);
            }
        }

        private HttpClient CreateHttpClient()
        {
            var handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
#if DEBUG
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (message, cert, chain, errors) => { return true; };
#endif
            var httpClient = new HttpClient(handler);

            httpClient.BaseAddress = new Uri(BaseUrl);
            httpClient.Timeout = TimeSpan.FromSeconds(Timeout);
            httpClient.DefaultRequestHeaders.Add("*Accept-Encoding*", "gzip, deflate, br");
            return httpClient;
        }

        public ApiService()
        {
            var httpClient = CreateHttpClient();
            catAPI = RestService.For<ICatAPI>(httpClient);
        }
    }
}
