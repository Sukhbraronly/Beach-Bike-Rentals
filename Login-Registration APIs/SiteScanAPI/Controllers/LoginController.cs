using Microsoft.AspNetCore.Mvc;
using KayakBikeRentalAPI.Model;
using KayakBikeRentalAPI.Services;

namespace KayakBikeRentalAPI.Controllers
{
    public class LoginController : ControllerBase
    {
        IloginService _loginService;
        public LoginController(IloginService service)
        {
            _loginService = service;
        }

        /// <summary>
        /// login user
        /// </summary>
        /// <param name="loginUserModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser([FromBody] LoginUserModel loginUserModel)
        {
            try
            {
                bool result = _loginService.IsAuthenticated(loginUserModel);
                if (!result) return BadRequest("Oops! Invalid username or password");
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
