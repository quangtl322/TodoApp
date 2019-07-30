using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models.User;
using TodoApp.Services;

namespace TodoApp.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class PhoneVerificationController : ControllerBase
    {
        private readonly IAuthyService _authyService;
        public PhoneVerificationController(IAuthyService authyService)
        {
            _authyService = authyService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegister model)
        {


            var AuthyId = await _authyService.registerUserAsync(model);


          ////   var result = await this.userManager.CreateAsync(user, model.Password);
          //  if (result.Succeeded)
          //  {
          //      await this.signInManager.SignInAsync(user, authenticationMethod: "AccountSecurityScheme", isPersistent: true);
          //      logger.LogInformation(3, "User created a new account with password.");
          //      return user;
          //  }
          //  else
          //  {
          //      AddErrors(result);
          //  }


           return Ok(AuthyId);
        }
    }
}