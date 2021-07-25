using curso.api.Filters;
using curso.api.Models;
using curso.api.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using curso.api.Extras;

namespace curso.api.Controllers
{


    [Route("api/v1/usuario")]
    [ApiController]
    public class Usuario : ControllerBase
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
            return Created("", loginViewModelInput);

        }






















    }
}
