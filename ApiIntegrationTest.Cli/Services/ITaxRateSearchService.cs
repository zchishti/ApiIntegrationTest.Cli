using ApiIntegrationTest.Cli.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntegrationTest.Cli.Services
{
    public interface ITaxRateSearchService
    {
       public Task<TaxRateSearchResult> SearchByZipCodeAsync(TaxRateSearchRequest request);
    }
}
