using curso.api.Models;
using curso.api.Models.Cuso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace curso.api.Controllers
{
    [Route("api/v1/cursos")]
    [ApiController]
    [Authorize]
    public class CursoController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="curso"></param>
        /// <returns> Permite criar cursos</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao Cadastrar o Curso")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPost]
        [Route("")]        
        public async Task<IActionResult> Post(CursoViewModelInput curso)
        {
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            return Created("", curso);
        }
        /// <summary>
        /// Este serviço permite obter todos os cursos ativos do usuario
        /// </summary>
        /// <returns> retorna status ok e dados do curso do usuario</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao Obter os Cursos")]
        [SwaggerResponse(statusCode: 401, description: "Não Autorizado")]
        [HttpGet]
        [Route("")]             
        public async Task<IActionResult> Get()
        {
            //var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var cursos = new List<CursoViewModelOutput>();            
            cursos.Add(new CursoViewModelOutput()
            {
                Login = "",
                Descricao = "teste",
                Nome = "teste 123456"
            });

            return Ok(cursos);
        }
    }
}
