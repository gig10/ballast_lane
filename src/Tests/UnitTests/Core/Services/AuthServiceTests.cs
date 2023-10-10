using GameDatabase.Core.Entities;
using GameDatabase.Core.Interfaces;
using GameDatabase.Core.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using FluentAssertions;

namespace UnitTests.Core.Services
{
    public class AuthServiceTests
    {
        private readonly Mock<IAuthRepository> repository = new Mock<IAuthRepository>();

        private const string VALID_USER = "test";
        private const string VALID_PASSWORD = "12345678";
        private const string VALID_EMAIL = "test@test.com";
        private const string VALID_HASHED_PASSWORD = @"$2a$11$2pSiv.icM2E6t3muegohoup6U6eqDYdoHviYrew7/9qtbzCqG5DL6";

        public AuthServiceTests()
        {
            repository.Setup(r => r.CreateUserAuthInformation(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string email, string hash, string user) => Task.FromResult(new Authentication()
                {
                    Id = 1,
                    Email = email,
                    UserName = user
                }));

            repository.Setup(r => r.GetAuthInformation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string email, string password) => Task.FromResult(
                    new Authentication()
                    {
                        Id = 1,
                        Email = email,
                        UserName = VALID_USER,
                        PasswordHash = VALID_HASHED_PASSWORD
                    }));
        }

        [Fact]
        public async Task SignupUser_Should_Return_Valid_Authentication()
        {
            //Arrange
            var expectedResult = new Authentication()
            {
                Id = 1,
                Email = VALID_EMAIL,
                PasswordHash = null,
                UserName = VALID_USER
            };

            var authService = new AuthService(repository.Object);

            //Act
            var result = await authService.SignupUser(VALID_EMAIL, VALID_PASSWORD, VALID_USER);

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task SigninUser_Should_Return_Valid_Authentication()
        {
            //Arrange
            var expectedResult = new Authentication()
            {
                Id = 1,
                Email = VALID_EMAIL,
                PasswordHash = VALID_HASHED_PASSWORD,
                UserName = VALID_USER
            };

            var authService = new AuthService(repository.Object);

            //Act
            var result = await authService.AuthenticateUser(VALID_EMAIL, VALID_PASSWORD);

            //Assert
            result.Should().BeEquivalentTo(expectedResult);

        }


        [Fact]
        public async Task SigninUser_InvalidCredentials_ShouldReturn_Null()
        {
            //Arrange
            var authService = new AuthService(repository.Object);

            //Act
            var result = await authService.AuthenticateUser(VALID_EMAIL, "asd");

            //Assert
            result.Should().Be(null);
        }
    }
}
