using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Domain.Model.Atores;
using LetsParty.Domain.ViewModel;
using LetsParty.Domain.Repository;
using LetsParty.Infra.Data.Context;
using System.Web.Security;
using System.Web;

namespace LetsParty.AppService.Log
{
   public  class LogService: IlogService
    {
        private ILogResository LogRepository { get; set; }
        private ILetsPartyContext LetsPartyContext { get; set; }

        public LogService(ILogResository logRepository, ILetsPartyContext lestPartyContext)
        {
            LogRepository = logRepository;
            LetsPartyContext = lestPartyContext;
        }

        public void GravaLog(LogEventos log)
        {
            LogRepository.Insert(log);
        }
    }
}
