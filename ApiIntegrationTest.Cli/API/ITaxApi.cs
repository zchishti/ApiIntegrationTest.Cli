using ApiIntegrationTest.Cli.API.Responses;
using System.Threading.Tasks;

namespace ApiIntegrationTest.Cli.API
{
    public interface ITaxApi
    {
        Task<TaxRateSearchResponse> SearchByZipCodeAsync(string zipcode);
    }
}