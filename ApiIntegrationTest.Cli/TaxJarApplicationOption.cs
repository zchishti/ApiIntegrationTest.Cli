using CommandLine;

namespace ApiIntegrationTest.Cli
{
    public class TaxJarApplicationOption
    {
        [Option('z', "zipcode", Required = true, HelpText = "Provide zipcode to get tax rates.")]
        public string ZipCode { get; set; }
    }
}