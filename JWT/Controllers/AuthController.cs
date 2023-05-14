using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using JWT.Models;
using JWT.Services;

namespace TestJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        #region

        /*
         {
              "FirstName": "ahmed",
              "LastName": "sayed",
              "Username": "ahmedsayed",
              "Email": "saye@gmail.com",
              "Password": "Ahmed_123"
          }
        */

        #endregion

        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await authService.RegisterAsync(model);

            //if user name or email is already exists
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);


            //return Ok({ token = result.Token, expireOn = result.ExpireOn});

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await authService.LoginAsync(model);

            //if user name or email is already exists
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);


            //return Ok({ token = result.Token, expireOn = result.ExpireOn});

            return Ok(result);
        }

        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await authService.AddRoleAsync(model);

            
            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);


            return Ok(model);
        }


    }
}
