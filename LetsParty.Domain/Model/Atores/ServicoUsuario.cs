using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Seedwork;

namespace LetsParty.Domain.Model.Atores
{
    public class ServicoUsuario:EntityBase
    {
        public Guid UsuarioID { get; set; }
        public Usuario usuario { get; set; }
        public Guid ServicoID { get; set; }
        public Servico servico { get; set; }
    }
}
