using LetsParty.Domain.Model.Atores;
using LetsParty.Seedwork.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsParty.Domain.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
    }
}
