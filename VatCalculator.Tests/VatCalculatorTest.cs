namespace VatCalculator.Tests
{
    using System.Net;
    using System.Net.Http.Json;
    using VatCalculator.Server.Enums;
    using VatCalculator.Server.Models;

    [TestClass]
    public class VatCalculatorTest
    {
        [TestClass]
        public class VatCalculationApiIntegrationTests
        {
            private readonly string baseUrl = "http://localhost:5000/api/";

            [TestMethod]
            public async Task CalculateVat_ShouldReturnCorrectResult_WhenNetAmountIsProvided()
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);

                var calculationRequest = new CalculationRequest
                {
                    Amount = 100m,
                    VatRate = 20m,
                    Type = AmountType.Net
                };

                var response = await client.PostAsJsonAsync("VatCalculation/calculate", calculationRequest);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<CalculationResponse>();

                // Validate the response
                Assert.IsNotNull(result);
                Assert.AreEqual(100m, result.NetAmount);
                Assert.AreEqual(120m, result.GrossAmount);
                Assert.AreEqual(20m, result.VatAmount);
            }

            [TestMethod]
            public async Task CalculateVat_ShouldReturnCorrectResult_WhenGrossAmountIsProvided()
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);

                var calculationRequest = new CalculationRequest
                {
                    Amount = 120m,
                    VatRate = 20m,
                    Type = AmountType.Gross
                };

                var response = await client.PostAsJsonAsync("VatCalculation/calculate", calculationRequest);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<CalculationResponse>();

                // Validate the response
                Assert.IsNotNull(result);
                Assert.AreEqual(100m, result.NetAmount);
                Assert.AreEqual(120m, result.GrossAmount);
                Assert.AreEqual(20m, result.VatAmount);
            }

            [TestMethod]
            public async Task CalculateVat_ShouldReturnCorrectResult_WhenVatAmountIsProvided()
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);

                var calculationRequest = new CalculationRequest
                {
                    Amount = 20m,
                    VatRate = 20m,
                    Type = AmountType.Vat
                };

                var response = await client.PostAsJsonAsync("VatCalculation/calculate", calculationRequest);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<CalculationResponse>();

                // Validate the response
                Assert.IsNotNull(result);
                Assert.AreEqual(100m, result.NetAmount);
                Assert.AreEqual(120m, result.GrossAmount);
                Assert.AreEqual(20m, result.VatAmount);
            }

            [TestMethod]
            public async Task CalculateVat_ShouldReturnBadRequest_WhenVatRateIsInvalid()
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);

                var calculationRequest = new CalculationRequest
                {
                    Amount = 100m,
                    VatRate = 50m, // Invalid VAT rate (valid: 10, 13, 20)
                    Type = AmountType.Net
                };

                var response = await client.PostAsJsonAsync("VatCalculation/calculate", calculationRequest);

                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

                var errorResponse = await response.Content.ReadAsStringAsync();
                StringAssert.Contains(errorResponse, "Invalid VAT rate. Valid rates are 10%, 13%, and 20%.");
            }

            [TestMethod]
            public async Task CalculateVat_ShouldReturnBadRequest_WhenAmountIsZeroOrNegative()
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);

                var calculationRequest = new CalculationRequest
                {
                    Amount = 0, // Invalid amount (zero or negative)
                    VatRate = 20m,
                    Type = AmountType.Net
                };

                var response = await client.PostAsJsonAsync("VatCalculation/calculate", calculationRequest);

                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

                var errorResponse = await response.Content.ReadAsStringAsync();
                StringAssert.Contains(errorResponse, "Net amount must be greater than zero.");
            }

            [TestMethod]
            public async Task CalculateVat_ShouldReturnBadRequest_WhenAmountTypeIsInvalid()
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);

                var calculationRequest = new CalculationRequest
                {
                    Amount = 100m,
                    VatRate = 20m,
                    Type = (AmountType)999 // Invalid AmountType
                };

                var response = await client.PostAsJsonAsync("VatCalculation/calculate", calculationRequest);

                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

                var errorResponse = await response.Content.ReadAsStringAsync();
                StringAssert.Contains(errorResponse, "Invalid amount type provided.");
            }

            [TestMethod]
            public async Task CalculateVat_ShouldReturnBadRequest_WhenVatAmountIsZeroOrNegative()
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);

                var calculationRequest = new CalculationRequest
                {
                    Amount = -50m, // Negative VAT amount
                    VatRate = 20m,
                    Type = AmountType.Vat
                };

                var response = await client.PostAsJsonAsync("VatCalculation/calculate", calculationRequest);

                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

                var errorResponse = await response.Content.ReadAsStringAsync();
                StringAssert.Contains(errorResponse, "VAT amount must be greater than zero.");
            }
        }
    }
}