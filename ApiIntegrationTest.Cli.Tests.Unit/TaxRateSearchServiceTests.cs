using ApiIntegrationTest.Cli.API;
using ApiIntegrationTest.Cli.API.Responses;
using ApiIntegrationTest.Cli.Mapping;
using ApiIntegrationTest.Cli.Models;
using ApiIntegrationTest.Cli.Services;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiIntegrationTest.Cli.Tests.Unit
{
    public class TaxRateSearchServiceTests
    {
        private readonly TaxRateSearchService _sut;
        private readonly ITaxApi _taxApi = Substitute.For<ITaxApi>();
        private readonly IFixture _fixture = new Fixture();

        public TaxRateSearchServiceTests(){
            _sut = new TaxRateSearchService(_taxApi);
        }

        [Fact]
        public async Task SearchByZipCodeAsync_ZipCodeValid()
        {
            const string zipcode = "73034";
            var request = new TaxRateSearchRequest(zipcode);

            var apiResponse = _fixture.Create<TaxRateSearchResponse>();
            _taxApi.SearchByZipCodeAsync(zipcode).Returns(apiResponse);
            var expectedResult = new TaxRateSearchResult {
                Rate = ApiToModelMapping.ToTaxRateResult(apiResponse.Rate)
            };
            
            var result = await _sut.SearchByZipCodeAsync(request);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task SearchByZipCodeAsync_ZipCodeInValid()
        {
            const string zipcode = "73034XYZ";
            var request = new TaxRateSearchRequest(zipcode);
            var result = await _sut.SearchByZipCodeAsync(request);

            result.Should().BeNull();
        }
    }
}
