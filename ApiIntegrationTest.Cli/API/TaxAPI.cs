using ApiIntegrationTest.Cli.API.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ApiIntegrationTest.Cli.API
{
    class TaxAPI: ITaxApi
    {
        private readonly HttpClient _httpClient;
        public TaxAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TaxRateSearchResponse> SearchByZipCodeAsync(string zipcode)
        {
            
            var response = await _httpClient.GetAsync($"rates/{zipcode}");
       
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<TaxRateSearchResponse>(jsonString);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
    }
}
