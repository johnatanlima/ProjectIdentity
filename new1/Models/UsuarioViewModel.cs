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

        [Required(ErrorMessage="Esse campo é obrigatóri!")]
        [DataType(DataType.Text)] 
        public string NomeUsuario { get; set; }
        public int Idade { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage="Informe uma expressao de email válida!")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [StringLength(7, ErrorMessage="Obseve o número de caracteres!")]
        public string Senha { get; set; }

    }
}