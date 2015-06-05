using System
namespace slnTCC.Domain.Entities
{
    public class Cliente
    {
        public int ClienteID { get; set; }

        public string Nome { get; set; }

        public string sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
