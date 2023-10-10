using AutoMapper;

using GameDatabase.API.AuthEndpoints.Payloads;
using GameDatabase.Core.Entities;

namespace GameDatabase.API.AuthEndpoints
{
    public class AuthenticationMapper : Profile
    {
        public AuthenticationMapper()
        {
            CreateMap<Authentication, SignupResponse>();
            CreateMap<Authentication, AuthResponse>();
        }
    }
}
