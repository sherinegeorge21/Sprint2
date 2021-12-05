using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication71.Models;

namespace WebApplication71.Controllers
{
    public class AuthController : Controller
    {
        private readonly IJwtAuthManager _jwtAuthManager;

        public AuthController(IJwtAuthManager jwtAuthManager)
        {
            _jwtAuthManager = jwtAuthManager;
        }

        [HttpPost]
        [Route("api/[controller]/login")]
        public IActionResult Login(UserCred userCred)
        {
            var token = _jwtAuthManager.Authenticate(userCred.Username, userCred.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
