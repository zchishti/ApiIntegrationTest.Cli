using ApiIntegrationTest.Cli.API;
using ApiIntegrationTest.Cli.Models;
using ApiIntegrationTest.Cli.Output;
using ApiIntegrationTest.Cli.Services;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiIntegrationTest.Cli
{
    public class TaxJarApplication
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly ITaxRateSearchService _taxRateSearchService;
        public TaxJarApplication(IConsoleWriter consoleWriter, ITaxRateSearchService taxRateSearchService)
        {
            _consoleWriter = consoleWriter;
            _taxRateSearchService = taxRateSearchService;
        }
        public async Task RunAsync(string[] args)
        {
            await Parser.Default
                .ParseArguments<TaxJarApplicationOption>(args)
                .WithParsedAsync(async option =>
                {
                    var searchRequest = new TaxRateSearchRequest(option.ZipCode);
                    var result = await _taxRateSearchService.SearchByZipCodeAsync(searchRequest);
                    var formattedResult = JsonSerializer.Serialize(result, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });
                    _consoleWriter.WriteLine(formattedResult);
                });
        }
    }
}
