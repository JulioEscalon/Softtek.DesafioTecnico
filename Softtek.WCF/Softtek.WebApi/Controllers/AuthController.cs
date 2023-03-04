using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Softtek.Service;
using Softtek.WebApi.Configuration;
using Softtek.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtek.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        ITokenHandlerService _service;

        public AuthController(UserManager<IdentityUser> userManager, ITokenHandlerService service)
        {
            _userManager = userManager;
            _service = service;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UsuarioDTO user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);
                if (existingUser != null)
                {
                    return BadRequest("El usuario ya existe");
                }

                var isCreated = await _userManager.CreateAsync(new IdentityUser() { Email = user.Email, UserName = user.User }, user.Password);

                if (isCreated.Succeeded)
                    return Ok();
                else
                    return BadRequest(isCreated.Errors.Select(x => x.Description).ToList());
            }
            else
                return BadRequest("Se produjo un error al registrar usuario");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UsuarioDTO user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);
                if (existingUser == null)
                {
                    return BadRequest("El usuario no existe");
                }

                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);

                if (isCorrect)
                {
                    var parameters = new TokenParameters()
                    {
                        Id = existingUser.Id,
                        PasswordAuth = existingUser.PasswordHash,
                        UserName = existingUser.UserName
                    };
                    var jwtToken = _service.GenerateJwtToken(parameters);
                    return Ok(jwtToken);
                }
                else
                    return BadRequest("Usuario o password no válido");
            }
            else
                return BadRequest("Se produjo un error al registrar usuario");
        }
    }
}
