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
            {    Email ="brunoco56@hotmail.com",
                Nome ="Bruno",
                Codigo = 1
            };

            var secret = Encoding.ASCII.GetBytes("Buz10s*19812341478hjghghjyk!$%6");

            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var SecurityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                (
                    new Claim[] {
                         new Claim(ClaimTypes.NameIdentifier,usuarioOutput.Codigo.ToString()),
                         new Claim(ClaimTypes.Name, usuarioOutput.Nome),
                         new Claim(ClaimTypes.Email, usuarioOutput.Email) 
                    }),

                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var tokenGenereted = jwtSecurityTokenHandler.CreateToken(SecurityTokenDescriptor);

           var token =  jwtSecurityTokenHandler.WriteToken(tokenGenereted);

            return Ok(new{Token = token,Usuario = usuarioOutput});

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
