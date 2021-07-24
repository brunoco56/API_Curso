using curso.api.Models.Cuso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CursoViewModelInput curso)
        {


            return Created("", curso);
        }
    }
}
