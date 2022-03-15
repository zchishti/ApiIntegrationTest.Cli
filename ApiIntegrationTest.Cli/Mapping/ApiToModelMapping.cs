using ApiIntegrationTest.Cli.API.Responses;
using ApiIntegrationTest.Cli.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiIntegrationTest.Cli.Mapping
{
    public static class ApiToModelMapping
    {
        public static TaxRateResult ToTaxRateResult(this TaxRateResponse response)
        {
            return new TaxRateResult()
            {
                City = response.City,
                CityRate = response.CityRate,
                CombinedDistrictRate = response.CombinedDistrictRate,
                CombinedRate = response.CombinedRate,
                CountryRate = response.CountryRate,
                CountyRate = response.CountyRate
            };
        }
    }
}
