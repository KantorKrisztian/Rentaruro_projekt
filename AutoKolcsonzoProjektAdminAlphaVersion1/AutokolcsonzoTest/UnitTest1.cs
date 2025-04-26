using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Threading;
using AutoKolcsonzoProjektAdminAlphaVersion1;

namespace AutokolcsonzoTest
{
    [TestClass]
    public class HttpRequestsTests
    {
        private Mock<HttpRequests> HttpRequests;
        private HttpClient client = new HttpClient();
        private HttpRequests _httpRequests;

        [TestInitialize]
        public void Setup()
        {
            HttpRequests = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            _mockHttpClient = new HttpClient(HttpRequests.Object);
            _httpRequests = new HttpRequests
            {
                client = _mockHttpClient // Inject the mocked HttpClient
            };
        }

        [TestMethod]
        public void EncodePassword_ShouldReturnBase64EncodedString()
        {
            // Arrange
            string password = "mySecurePassword123!";
            string expectedEncoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));

            // Act
            string result = _httpRequests.EncodePassword(password);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedEncoded, result);
        }

        [TestMethod]
        public void DecodePassword_ShouldReturnOriginalString()
        {
            // Arrange
            string originalPassword = "mySecurePassword123!";
            string encodedPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(originalPassword));

            // Act
            string result = _httpRequests.DecodePassword(encodedPassword);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(originalPassword, result);
        }

        [TestMethod]
        public async Task Login_ShouldReturnTrue_WhenResponseIsSuccessful()
        {
            // Arrange
            var mockResponse = new
            {
                message = "Login successful",
                token = "mockToken",
                role = "Admin"
            };
            string jsonResponse = JsonConvert.SerializeObject(mockResponse);

            HttpRequests
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json")
                });

            // Act
            bool result = await _httpRequests.Login("testUser", "testPassword");

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task ListAllCars_ShouldReturnListOfCars_WhenResponseIsSuccessful()
        {
            // Arrange
            var mockCars = new List<jsonCars>
            {
                new jsonCars { id = 1, brand = "Toyota", licensePlate = "ABC123" },
                new jsonCars { id = 2, brand = "Honda", licensePlate = "XYZ789" }
            };
            string jsonResponse = JsonConvert.SerializeObject(mockCars);

            HttpRequests
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json")
                });

            // Act
            var result = await _httpRequests.ListAllCars();

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, result.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Toyota", result[0].brand);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Honda", result[1].brand);
        }

        [TestMethod]
        public async Task CreateCar_ShouldReturnUpdatedListOfCars_WhenResponseIsSuccessful()
        {
            // Arrange
            var newCar = new jsonCars { id = 3, brand = "Ford", licensePlate = "DEF456" };
            var updatedCars = new List<jsonCars>
            {
                new jsonCars { id = 1, brand = "Toyota", licensePlate = "ABC123" },
                new jsonCars { id = 2, brand = "Honda", licensePlate = "XYZ789" },
                newCar
            };
            string jsonResponse = JsonConvert.SerializeObject(new { message = "Car added successfully" });
            string updatedCarsResponse = JsonConvert.SerializeObject(updatedCars);

            HttpRequests
                .Protected()
                .SetupSequence<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json")
                })
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(updatedCarsResponse, Encoding.UTF8, "application/json")
                });

            // Act
            var result = await _httpRequests.CreateCar(newCar);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(3, result.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result.Exists(car => car.brand == "Ford" && car.licensePlate == "DEF456"));
        }
    }
}