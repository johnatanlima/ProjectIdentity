using Microsoft.AspNetCore.Identity;

namespace new1.Models
{
    public class NivelAcesso : IdentityRole
    {
        public string Descricao { get; set; }
    }
}

//Assim como temos a classe (tabela) para criarmos um UsuarioIdentity,
//que possui vários atributos já pré-estabelecidos, e que podemos her
//dar conforme desejamos, para niveis de acesso, ainda do proprio 
//Identity temos a classe IdentityRole. Essa classe tambem ja possui
//atributos padrões, e o que podemos fazer é utilizar ela de acordo
//como desejamos. Nesse caso, herdamos dela e ela possui relaciona
//mentos com a classe Users para podermos relacionar acesso a users.  
