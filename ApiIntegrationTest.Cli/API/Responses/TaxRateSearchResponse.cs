using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ApiIntegrationTest.Cli.API.Responses
{
    public class TaxRateSearchResponse
    {
        [JsonPropertyName("rate")]
        public TaxRateResponse Rate { get; set; }
    }
}
