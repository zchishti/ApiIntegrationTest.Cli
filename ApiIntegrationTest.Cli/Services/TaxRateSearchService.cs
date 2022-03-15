using ApiIntegrationTest.Cli.API;
using ApiIntegrationTest.Cli.Mapping;
using ApiIntegrationTest.Cli.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApiIntegrationTest.Cli.Services
{
    public class TaxRateSearchService : ITaxRateSearchService
    {
        private readonly ITaxApi _taxApi;

        public TaxRateSearchService(ITaxApi taxApi)
        {
            _taxApi = taxApi;
        }
        public async Task<TaxRateSearchResult> SearchByZipCodeAsync(TaxRateSearchRequest request)
        {
            var _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";

            if ((!Regex.Match(request.ZipCode, _usZipRegEx).Success)){
                Console.WriteLine("Invalid ZipCode");
                return null;
            }

            try
            {
                var response = await _taxApi.SearchByZipCodeAsync(request.ZipCode);
                return new TaxRateSearchResult
                {
                    Rate = ApiToModelMapping.ToTaxRateResult(response.Rate)
                };
            }catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return null;
        }
    }
}
