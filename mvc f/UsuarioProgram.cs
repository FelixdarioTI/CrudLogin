using Microsoft.AspNetCore.Mvc;

namespace mvc_f.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(usuario.Nome) || string.IsNullOrEmpty(usuario.Loginusuario) || string.IsNullOrEmpty(usuario.Telefone) || string.IsNullOrEmpty(usuario.Endereco) || string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Senha))
                {
                    TempData["ErrorMessage"] = "Todos os campos são obrigatórios.";
                    return RedirectToAction("Privacy", "Home");
                }

                if (_usuarioRepository.UsuarioJaExiste(usuario.Email))
                {
                    TempData["ErrorMessage"] = "Este email já está cadastrado.";
                    return RedirectToAction("Privacy", "Home");
                }

                _usuarioRepository.CadastrarUsuario(usuario);
                TempData["SuccessMessage"] = "Usuário cadastrado com sucesso!";
                return RedirectToAction("Entrar", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = "Por favor, preencha todos os campos corretamente.";
                return RedirectToAction("Privacy", "Home");
            }
        }

    }



}
