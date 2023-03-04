using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Softtek.Application;
using Softtek.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtek.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AsesorController : ControllerBase
    {
        IApplication<Asesor> _asesor;

        public AsesorController(IApplication<Asesor> asesor)
        {
            _asesor = asesor;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_asesor.GetAll());
        }

        [HttpPost]
        public IActionResult Save(Asesor asesor)
        {
            var a = new Asesor()
            {
                Name = asesor.Name,
                LastName = asesor.LastName
            };

            return Ok(_asesor.Save(a));
        }
    }
}
