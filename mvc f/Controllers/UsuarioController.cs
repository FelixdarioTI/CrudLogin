using Microsoft.AspNetCore.Mvc;
using System;
namespace mvc_f.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RegistroController : ControllerBase
    {
        [HttpPost]
        public IActionResult RegistrarUsuario([FromBody] UsuarioDTO usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nome))
                return BadRequest("O nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(usuario.Email))
                return BadRequest("O email é obrigatório.");


            try
            {
                return Ok("Usuário registrado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao processar o registro do usuário.");
            }
        }
    }

    public class UsuarioDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Loginusuario { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string SenhaConfirm { get; set; }
    }

}
