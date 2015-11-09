using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Domain.Model.Atores;
using LetsParty.Domain.ViewModel;
using LetsParty.Domain.Repository;
using LetsParty.Infra.Data.Context;

namespace LetsParty.AppService.Status
{
    public class StatusService : IStatusService
    {
        private ILetsPartyContext Context;
        private IStatusRepository StatusRepository;

        public StatusService(ILetsPartyContext context, IStatusRepository statusRepository)
        {
            Context = context;
            StatusRepository = statusRepository;
        }


        public Guid ObtemStatusPadrao()
        {
            Guid IdStatus = StatusRepository.All().SingleOrDefault(s => s.status.Contains("Aguardando análise do fornecedor")).Id;
            return IdStatus;
        }

        public string RetornaStatusAtual(Guid Id)
        {
            string Status = StatusRepository.All().SingleOrDefault(s => s.Id == Id).status;
            return Status;
        }

        public IQueryable<StatusEvento> RetornaStatus()
        {
            return StatusRepository.All();
        }
    }
}
