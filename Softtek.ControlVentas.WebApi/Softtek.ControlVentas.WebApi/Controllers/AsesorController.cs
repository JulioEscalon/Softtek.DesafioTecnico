using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Softtek.ControlVentas.Application;
using Softtek.ControlVentas.Entity;
using System.Collections.Generic;

namespace Softtek.ControlVentas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsesorController : ControllerBase
    {
        IApplication<Asesor> _asesor;
        AsesorController(IApplication<Asesor> asesor)
        {
            _asesor = asesor;
        }
    }
}
