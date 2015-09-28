using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Seedwork;

namespace LetsParty.Domain.Model.Atores
{
    public class Acesso : EntityBase
    {
        public Guid PerfilID { get; set; }
        public Perfil perfil { get; set; }
        public Guid PermissaoID { get; set; }
        public Permissao permissao { get; set; }
    }
}
