using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_f.Models
{
    [Table("ClassUser")]
    public class ClassUser
    {
        [Display(Name = "Código")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Usúario")]
        [Column("Loginusuario")]
        public string Loginusuario { get; set; }

        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; }
        [Display(Name = "Email")]
        [Column("Email")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [Column("Telefone")]
        public string Telefone { get; set; }
        [Display(Name = "Endereço")]
        [Column("Endereco")]
        public string Endereco { get; set; }
        [Display(Name = "Senha")]
        [Column("Senha")]
        public string Senha { get; set; }
        [Display(Name = "Confirme senha")]
        [Column("SenhaConfirm")]
        public string SenhaConfirm { get; set; }
    }
}
