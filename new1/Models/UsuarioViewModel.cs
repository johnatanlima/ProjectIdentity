using System.ComponentModel.DataAnnotations;

namespace new1.Models
{
    public class UsuarioViewModel
    {   
        [Required(ErrorMessage="Esse campo é obrigatório!")]
        [DataType(DataType.Text)]
        public string Nome {get; set;}

        [Required(ErrorMessage="Esse campo é obrigatório!")]
        [DataType(DataType.Text)]
        public string Sobrenome { get; set; }

        [Range(1, 120, ErrorMessage="O campo é apenas números!")]
        [StringLength(3, ErrorMessage="No máximo 3 caracteres!")]
        public int Idade { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage="Informe uma expressao de email válida!")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Range(6, 32, ErrorMessage="Obseve o número de caracteres!")]
        public string Senha { get; set; }

    }
}