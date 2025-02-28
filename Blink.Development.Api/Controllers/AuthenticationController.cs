using Blink.Development.Authentication.Models.DTOs.Incoming;
using Blink.Development.Authentication.Models.DTOs.OutGoing;
using Blink.Development.Entities;
using Blink.Development.Entities.Dtos;
using Blink.Development.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blink.Development.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AuthenticationController> _logger;
        //private readonly JwtConfig _jwtConfig;

        public AuthenticationController(
            UserManager<User> userManager,
            IConfiguration configuration,
            ILogger<AuthenticationController> logger,
            RoleManager<IdentityRole> roleManager
        //JwtConfig jwtConfig
        )
        {
            _userManager = userManager;
            //_jwtConfig = jwtConfig;
            _configuration = configuration;
            _roleManager = roleManager;
            _logger = logger;
        }




        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto requestDto)
        {
            // validate incoming request
            if (ModelState.IsValid)
            {
                // we need to check if the email is already exist
                var user_exist = await _userManager.FindByEmailAsync(requestDto.Email);
                if (user_exist != null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>() {
                            "Email already exist"
                        },
                        Success = false
                    });
                }

                var new_user = new User()
                {
                    Email = requestDto.Email,
                    UserName = requestDto.Email,
                    PhoneNumber = requestDto.PhoneNumber,
                    Name = requestDto.Name,
                    TypeOfUser = (Blink.Development.Entities.Entities.UserType)requestDto.UserType,
                    StoreAddress = requestDto.StoreAddress,
                    StorePhoneNumber = requestDto.StorePhoneNumber,
                    StoreBranchId = requestDto.StoreBranchId,
                    DeliveryAddress = requestDto.DeliveryAddress,
                    DeliveryPhoneNumber = requestDto.DeliveryPhoneNumber,
                    DeliveryBranchId = requestDto.DeliveryBranchId,
                    Balance = requestDto.Balance,
                    Inventory = new List<Inventory>(),
                    Mission = new List<Mission>(),
                };

                // create user
                var is_created = await _userManager.CreateAsync(new_user, requestDto.Password);
                if (is_created.Succeeded)
                {
                    await _userManager.AddToRoleAsync(new_user, "User");
                    // generate jwt token
                    var token = GenerateJwtToken(new_user);

                    return Ok(new AuthResult()
                    {
                        Success = true,
                        Token = token,

                    });
                }
                else
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = is_created.Errors.Select(x => x.Description).ToList(),
                        Success = false
                    });
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            return Ok(users);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var existing_user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (existing_user == null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>() {
                            "Invalid login request"
                        },
                        Success = false
                    });
                }
                var is_valid = await _userManager.CheckPasswordAsync(existing_user, loginDto.Password);
                if (is_valid)
                {
                    var jwtToken = GenerateJwtToken(existing_user);
                    return Ok(new AuthResult()
                    {
                        Success = true,
                        Token = jwtToken
                    });
                }
                else
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>() {
                            "Invalid login request"
                        },
                        Success = false
                    });
                }
            }
            return BadRequest(new AuthResult()
            {
                Errors = new List<string>()
                {
                    "Invalid payload"
                },
                Success = false
            });
        }

        private string GenerateJwtToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var claims = AddAllValidClaims(user).Result;

            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);

            // Token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }

        private async Task<List<Claim>> AddAllValidClaims(User user)
        {
            var claims = new List<Claim>
            {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString())
            };
            var roles = await _userManager.GetClaimsAsync(user);
            claims.AddRange(roles);

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role == null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (var roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }

            }
            return claims;
        }
    }
}
