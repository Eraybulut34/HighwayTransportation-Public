using System.Collections.Generic;
using System.Linq;
using MapsterMapper;
using HighwayTransportation.Providers;
using HighwayTransportation.Services;
using HighwayTransportation.Domain.Entities;
using HighwayTransportation.Core;
using HighwayTransportation.Core.Dtos;


namespace HighwayTransportation.Providers
{
    public class AppUserProvider : ProviderBase<AppUserService, AppUser> 
    {
        IMapper _mapper;
        AppUserService _appUserService;

        public AppUserProvider(AppUserService appUserService, IMapper mapper) : base(appUserService)
        {
            _mapper = mapper;
            _appUserService = appUserService;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var user = await _appUserService.GetByQueryAsync(x => x.Email == loginRequest.Email && x.Password == loginRequest.Password);
            if (user == null)
            {
                return new LoginResponse
                {
                    IsSuccess = false,
                    Message = "User not found"
                };
            }
            else
            {
                return new LoginResponse
                {
                    IsSuccess = true,
                    Message = "Login Success",
                    User = _mapper.Map<AppUserDto>(user)
                };
            }
        }
    }
}