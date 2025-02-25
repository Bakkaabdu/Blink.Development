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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AuthenticationController> _logger;
        //private readonly JwtConfig _jwtConfig;

        public AuthenticationController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<AuthenticationController> logger,
            IConfiguration configuration
        //JwtConfig jwtConfig
        )
        {
            _userManager = userManager;
            //_jwtConfig = jwtConfig;
            _configuration = configuration;
            _roleManager = roleManager;
            _logger = logger;
        }

        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(string name)
        {
            var roleExist = await _roleManager.RoleExistsAsync(name);
            if (!roleExist)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(name));
                if (roleResult.Succeeded)
                {
                    _logger.LogInformation($"Role {name} created successfully");
                    return Ok(new
                    {
                        result = $"Role {name} created successfully"
                    });
                }
                else
                {
                    _logger.LogInformation($"Role {name} has not been created");
                    return BadRequest(new
                    {
                        erorr = $"Role {name} has not been created"
                    });
                }
            }
            return BadRequest(new
            {
                erorr = $"Role {name} already exist"
            });
        }
        [HttpGet("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            return Ok(users);
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
                        Result = false
                    });
                }

                var new_user = new IdentityUser()
                {
                    Email = requestDto.Email,
                    UserName = requestDto.Email
                };
                // create user
                var is_created = await _userManager.CreateAsync(new_user, requestDto.Password);
                if (is_created.Succeeded)
                {
                    // generate jwt token
                    var token = GenerateJwtToken(new_user);

                    return Ok(new AuthResult()
                    {
                        Result = true,
                        Token = token
                    });
                }
                else
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = is_created.Errors.Select(x => x.Description).ToList(),
                        Result = false
                    });
                }
            }

            return BadRequest(ModelState);
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
                        Result = false
                    });
                }
                var is_valid = await _userManager.CheckPasswordAsync(existing_user, loginDto.Password);
                if (is_valid)
                {
                    var jwtToken = GenerateJwtToken(existing_user);
                    return Ok(new AuthResult()
                    {
                        Result = true,
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
                        Result = false
                    });
                }
            }
            return BadRequest(new AuthResult()
            {
                Errors = new List<string>()
                {
                    "Invalid payload"
                },
                Result = false
            });
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);

            // Token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString())
                }),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
