
using Microsoft.AspNetCore.Mvc;
using System;

namespace mvc_f.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] CredenciaisDTO credenciais)
        {
           
            if (credenciais.Usuario != "usuario" || credenciais.Senha != "senha")
            {
                return Unauthorized("Usuário ou senha incorretos.");
            }

            
            return Ok("Login bem-sucedido!");
        }
    }

    public class CredenciaisDTO
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
