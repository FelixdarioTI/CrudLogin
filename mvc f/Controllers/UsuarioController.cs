namespace mvc_f.Controllers
{

    using System.Linq;

    public class UsuarioRepository
    {
        private static List<Usuario> usuarios = new List<Usuario>();
        private static int nextId = 1;

        public void CadastrarUsuario(Usuario usuario)
        {
            usuario.Id = nextId++;
            usuarios.Add(usuario);
        }

        public Usuario FazerLogin(string email, string senha)
        {
            return usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public bool UsuarioJaExiste(string email)
        {
            return usuarios.Any(u => u.Email == email);
        }
    }

}
