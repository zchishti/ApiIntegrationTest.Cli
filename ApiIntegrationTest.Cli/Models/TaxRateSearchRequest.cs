using System;
using System.Collections.Generic;
using System.Text;

namespace ApiIntegrationTest.Cli.Models
{
    public class TaxRateSearchRequest
    {
        public TaxRateSearchRequest(string zipcode)
        {
            ZipCode = zipcode;
        }
        public string ZipCode { get; }
    }
}
