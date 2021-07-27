using curso.api.Business.Entities;
using curso.api.Extras;
using curso.api.Filters;
using curso.api.Infraestruture.Data;
using curso.api.Models;
using curso.api.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace curso.api.Controllers
{


    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao Autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos Obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro Interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStatePersonalizado]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            var usuarioOutput = new UsuarioViewModelOutput
            { 
                Email ="brunoco56@hotmail.com",
                Nome ="Bruno",
                Codigo = 1
            };
            string secret = "Buz10s*1981234235657568#%&$&%";

            var token = new Token();
            

            var tokenT =  token.GenerarJwtToken(usuarioOutput.Codigo, secret);

            return Ok(new{Token = tokenT,Usuario = usuarioOutput});

        }

        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelStatePersonalizado]
        public IActionResult Registrar(RegistroViewModelInput loginViewModelInput)
        {
            var options = new DbContextOptionsBuilder<CursosDbContext>();

            options.UseSqlServer("Server = localhost; Database = Curso;");            

            CursosDbContext contexto = new CursosDbContext(options.Options);

            var usuario = new Usuario();

            usuario.Login = loginViewModelInput.Login;
            usuario.Email = loginViewModelInput.Email;
            usuario.Senha = loginViewModelInput.Senha;
            contexto.Usuario.Add(usuario);
            contexto.SaveChanges();

            return Created("", loginViewModelInput);

        }






















    }
}
