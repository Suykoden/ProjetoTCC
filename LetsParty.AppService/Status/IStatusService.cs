using System;
using LetsParty.Domain.Model.Atores;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsParty.AppService.Status
{
   public  interface IStatusService
    {
       Guid ObtemStatusPadrao();
    }
}
