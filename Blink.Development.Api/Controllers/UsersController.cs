using Blink.Development.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blink.Development.Api.Controllers
{

    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AuthenticationController> _logger;
        //private readonly JwtConfig _jwtConfig;

        public UsersController(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<AuthenticationController> logger
        //JwtConfig jwtConfig
        )
        {
            _userManager = userManager;
            //_jwtConfig = jwtConfig;
            _roleManager = roleManager;
            _logger = logger;
        }

        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }

        [HttpGet("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            return Ok(users);
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

        [HttpPost("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation($"the user with email {email} does not exist");
                return BadRequest(new
                {

                    error = $"User with Email {email} not found"
                });
            }
            var role = await _roleManager.RoleExistsAsync(roleName);
            if (!role)
            {
                _logger.LogInformation($"the role {email} does not exist");
                return BadRequest(new
                {

                    error = $"role doesnt exist"
                });
            }
            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                return Ok(new
                {
                    result = $"User {user.UserName} added to role {roleName}"
                });
            }
            return BadRequest(new
            {
                error = $"User {user.UserName} has not been added to role {roleName}"
            });
        }

        [HttpGet("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest(new
                {
                    error = $"User with Email {email} not found"
                });
            }
            var roles = await _userManager.GetRolesAsync(user);
            return Ok(new
            {
                roles = roles
            });
        }

        [HttpPost("RemoveUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest(new
                {
                    error = $"User with Email {email} not found"
                });
            }
            var role = await _roleManager.RoleExistsAsync(roleName);
            if (!role)
            {
                return BadRequest(new
                {
                    error = $"role doesnt exist"
                });
            }
            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                return Ok(new
                {
                    result = $"User {user.UserName} removed from role {roleName}"
                });
            }
            return BadRequest(new
            {
                error = $"User {user.UserName} has not been removed from role {roleName}"
            });
        }
    }
}
