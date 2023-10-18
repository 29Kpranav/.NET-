using Authentication_Authorization.Models;
using Authentication_Authorization.Models.Authentication.SignUp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string Role)
        {
           //check user exist
           var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
           if (userExist == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Error", Message = "User alredy exists!"});
            }
            // add the user in the database 
            IdentityUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),  
                UserName= registerUser.UserName,
            };
            if (await _roleManager.RoleExistsAsync(Role))
            {
                var result = await _userManager.CreateAsync(user, registerUser.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Failed to Create" });
                }
                //Add role to the user..

                 await _userManager.AddToRolesAsync(user,null); // Role
                 return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "User Created Successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "This Role doesnot Exist." });
            }
            //Assign a role

        }

    }
}
 