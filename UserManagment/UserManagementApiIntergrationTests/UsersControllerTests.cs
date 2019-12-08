using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using UserManagementAPI.Controllers.ViewModels;

namespace UserManagementApiIntegrationTests
{
    public class UsersControllerTests
    {
        private ApiWebApplicationFactory _webApplicationFactory;
        private readonly string _createUserUri = "";

        [OneTimeSetUp]
        public void Setup()
        {
            _webApplicationFactory = new ApiWebApplicationFactory();
        }


        [Test]
        public async Task AddUser_GivenNewUsername_ShouldPass()
        {
            // Arrange
            var httpClient = _webApplicationFactory.CreateClient();
            var request = new UserViewModel
            {
                UserName = Guid.NewGuid().ToString(),
                FullName = "Majdee Zoabi"
            };

            // Act
            var httpResponse = await httpClient.PostAsJsonAsync(_createUserUri, request);

            // Assert
            Assert.IsTrue(httpResponse.IsSuccessStatusCode);



        }
    }
}