using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Domain.Model.Atores;
using LetsParty.Seedwork.Repository;

namespace LetsParty.Domain.Repository
{
    public  interface IStatusRepository: IRepository<StatusEvento>
    {
    }
}
