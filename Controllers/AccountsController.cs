using System;
using System.Threading.Tasks;
using First.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace First.Controllers {
    [ApiController]
    [Route ("api/accounts")]
    public class AccountsController : ControllerBase {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;

        public AccountsController (
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration
        ) {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [HttpPost ("create")]
        public async Task<ActionResult<UserToken>> CreateUser ([FromBody] UserInfo model) {
            var user = new IdentityUser { UserName = model.EmailAddress, Email = model.EmailAddress };
            var result = await userManager.CreateAsync (user, model.Password);
            if (result.Succeeded) {
                return new UserToken ();
            } else {
                return BadRequest (result.Errors);
            }
        }

    }
}