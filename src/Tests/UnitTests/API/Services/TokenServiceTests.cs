using FluentAssertions;

using GameDatabase.API.Extensions;
using GameDatabase.API.Services;
using GameDatabase.Core.Entities;

using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Moq;

using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace UnitTests.API.Services
{
    public class TokenServiceTests
    {
        const int VALID_USER_ID = 1;
        const string VALID_ISSUER = "https://localhost:5235/";
        const string VALID_AUDIENCE = "https://localhost:5235/";
        const string VALID_EMAIL = "test@test.com";
        const string VALID_USER = "test";
        const string VALID_KEY = @"1f40fc92da241694750979ee6cf582f2d5d7d28e18335de05abc54d0560e0f5302860c652bf08d560252aa5e74210546f369fbbbce8c12cfc7957b2652fe9a75";

        private readonly Mock<IOptions<JwtOptions>> _options = new Mock<IOptions<JwtOptions>>();
        public TokenServiceTests()
        {
            _options.Setup(o => o.Value).Returns(() =>
                new JwtOptions()
                {
                    Audience = VALID_AUDIENCE,
                    Issuer = VALID_ISSUER,
                    Key = VALID_KEY
                });
        }

        [Fact]
        public void IssuedToken_ShouldBeValid_WithExpectedClaims()
        {
            //Arrange
            var authInfo = new Authentication()
            {
                Id = VALID_USER_ID,
                Email = VALID_EMAIL,
                UserName = VALID_USER,
            };

            var tokenService = new TokenService(_options.Object);

            //Act
            string jwtToken = tokenService.IssueTokenForAuthentication(authInfo);

            //Assert
            HelperMethods.ValidateToken(jwtToken, VALID_USER_ID, VALID_USER, VALID_EMAIL, _options.Object.Value)
                .Should()
                .BeTrue();
        }

        [Fact]
        public void EmptyAuth_ShouldThrowArgumentException()
        {
            //Arrange
            Authentication authInfo = null;
            var tokenService = new TokenService(_options.Object);


            //Act

            Action act = () => tokenService.IssueTokenForAuthentication(authInfo);

            //Assert
            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("auth");
        }

    }
}
