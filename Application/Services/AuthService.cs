using Application.DataTransferObjects.AuthDtos;
using Application.Services.Contracts;
using Application.Utilities;
using Domain.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        private readonly string _secretKey;
        private User? _user;

        public AuthService(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<JWT> jwtSettings,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwtSettings.Value;
            _secretKey = configuration.GetSection(AppConstants.SECRET).Value!;
        }

        public async Task<TokenDto> CreateToken(bool populateExpiry)
        {
            var siginingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(siginingCredentials, claims);
            var refreshToken = GenerateRefreshToken();
            _user!.RefreshToken = refreshToken;
            if (populateExpiry)
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(AppConstants.ExpiryDays);
            //_user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(1);
            await _userManager.UpdateAsync(_user);
            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new TokenDto(accessToken, refreshToken);

        }

        public async Task<(IdentityResult, TokenDto)> RegisterUser(RegistrationDto userForRegistration)
        {
            var userName = $"{userForRegistration?.LastName?.ToLower()}{userForRegistration?.NationalID?.Substring(0, 5)}";
            var user = new User
            {
                Email = userForRegistration?.Email,
                FirstName = userForRegistration?.FirstName!,
                LastName = userForRegistration?.LastName!,
                PhoneNumber = userForRegistration?.PhoneNumber,
                NationalID = userForRegistration?.NationalID!,
                UserName = userName,
            };

            var result = await _userManager.CreateAsync(user, userForRegistration?.Password!);
            if (result.Succeeded && userForRegistration?.Roles is not null)
                await _userManager.AddToRolesAsync(user, userForRegistration.Roles);
            _user = user;
            var tokenDto = await CreateToken(populateExpiry: true);
            return (result: result, tokenDto: tokenDto);
        }

        public async Task<bool> ValidateUser(LoginDto userForAuth)
        {
            _user = await _userManager.FindByEmailAsync(userForAuth.Email!);
            var result = (_user is not null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password!));
            return result;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false,
                ValidIssuer = _jwt.ValidIssuer!,
                ValidAudience = _jwt.ValidAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey))
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var prinicpal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken is null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid Token");
            }
            return prinicpal;
        }
        private SigningCredentials GetSigningCredentials()
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim("uid", _user!.Id)
            };
            var roles = await _userManager.GetRolesAsync(_user);
            //foreach (var role in roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}
            claims.Add(new Claim("roles", JsonSerializer.Serialize(roles)));

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwt.ValidIssuer,
                audience: _jwt.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwt.Expires)),
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
            var user = await _userManager.FindByIdAsync(principal.Claims.First(c => c.Type == "uid").Value);
            if (user is null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new Exception("Invalid client request. the tokenDot has some invalid values");
            _user = user;
            return await CreateToken(populateExpiry: false);
        }

        public async Task<IEnumerable<UserDto>> GetStaffsAsync()
        {
            return await GetUsersAsync(
                predicate: x => x.IsStaff,
                selector: x => new UserDto(
                        x.Id,
                        $"{x.FirstName} {x.LastName}",
                        x.NationalID,
                        x.Email!)
                );
        }
        private async Task<IEnumerable<TResult>> GetUsersAsync<TResult>(
                Expression<Func<User, bool>> predicate,
                Expression<Func<User, TResult>> selector
            )
        {
            return await _userManager
                .Users
                .Where(predicate)
                .Select(selector)
                .ToListAsync();
        }


        public async Task<IEnumerable<RoleDto>> GetRolesAsync()
        {
            return await _roleManager
                .Roles
                .Select(
                    r => new RoleDto(
                        r.Id,
                        r.Name!)
                    ).ToArrayAsync();
        }

        public async Task<IdentityResult> CreateRoleAsync(RoleForCreationDto role)
        {
            var roleDb = new IdentityRole
            {
                Name = role.Name
            };
            var result = await _roleManager.CreateAsync(roleDb);
            return result;
        }

        public async Task<IdentityResult> UpdateRoleAsync(string id, RoleForUpdateDto role)
        {
            var roleFromDb = await GetRoleAndCheckIfItExist(id);
            roleFromDb.Name = role.Name;
            var result = await _roleManager.UpdateAsync(roleFromDb);
            return result;
        }

        private async Task<IdentityRole> GetRoleAndCheckIfItExist(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role is null)
                throw new Exception($"The Role With Id: {roleId} doesn't exist");
            return role;
        }
    }
}
