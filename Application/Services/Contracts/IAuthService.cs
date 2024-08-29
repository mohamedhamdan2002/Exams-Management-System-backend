using Application.DataTransferObjects.AuthDtos;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Contracts
{
    public interface IAuthService
    {
        Task<(IdentityResult, TokenDto)> RegisterUser(RegistrationDto userForRegistration);
        Task<bool> ValidateUser(LoginDto userForAuth);
        Task<TokenDto> CreateToken(bool populateExpiry);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        Task<IEnumerable<UserDto>> GetStaffsAsync();
        Task<IEnumerable<RoleDto>> GetRolesAsync();
        Task<IdentityResult> CreateRoleAsync(RoleForCreationDto role);
        Task<IdentityResult> UpdateRoleAsync(string id, RoleForUpdateDto role);
    }
}
