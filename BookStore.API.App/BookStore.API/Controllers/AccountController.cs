﻿using BookStore.API.Modesl;
using BookStore.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody]SignUpModel signUpModel)
        {
            var result = await accountRepository.SignUpAsync(signUpModel);

            if ( result.Succeeded) return Ok(result);
            return Unauthorized(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] SignInModel signIpModel)
        {
            var result = await accountRepository.LoginAsync(signIpModel);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
