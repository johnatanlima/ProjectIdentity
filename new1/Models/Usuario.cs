using Microsoft.AspNetCore.Identity;

namespace new1.Models
{
    public class Usuario : IdentityUser
    {

        public string Nome {get; set;}
        public string Sobrenome { get; set; }
        public int Idade {get; set;}
    }
}