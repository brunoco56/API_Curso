using curso.api.Models.Cuso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace curso.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao Cadastrar o Curso")]
        [SwaggerResponse(statusCode: 401, description: "Campos Obrigatórios")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CursoViewModelInput curso)
        {
            var codigoUsuario = int.Parse(User.FindFirst(c=> c.Type == ClaimTypes.NameIdentifier)?.Value);

            return Created("", curso);
        }






        [SwaggerResponse(statusCode: 200, description: "Sucesso ao Obter os Cursos")]
        [SwaggerResponse(statusCode: 401, description: "Não Autorizado")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var cursos = new List<CursoViewModelInput>();




            return Ok();
        }



    }
}
