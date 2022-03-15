using System.Text.Json.Serialization;

namespace ApiIntegrationTest.Cli.API.Responses
{
    public class TaxRateResponse
    { 
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("city_rate")]
        public string CityRate { get; set; }

        [JsonPropertyName("combined_district_rate")]
        public string CombinedDistrictRate { get; set; }

        [JsonPropertyName("combined_rate")]
        public string CombinedRate {get; set; }

        [JsonPropertyName("country_rate")]
        public string CountryRate { get; set; }

        [JsonPropertyName("county_rate")]
        public string CountyRate { get; set; }
    }
}