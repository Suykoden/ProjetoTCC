using LetsParty.Domain.Repository;
using LetsParty.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Domain.Model.Atores;
using LetsParty.AppService.Usuarios.DTO;
using System.Web.Security;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using System.Net;

namespace LetsParty.AppService.Servicos
{
    public class ServicoServices : IServicoServices
    {
        private IServicoRepository ServicoRepository { get; set; }
        private ILetsPartyContext LetsPartyContext { get; set; }

        public ServicoServices(IServicoRepository servicoRepository, ILetsPartyContext context)
        {
            ServicoRepository = servicoRepository;
            LetsPartyContext = context;
        }

        public IQueryable<Servico> RetornaServicos()
        {
            return ServicoRepository
                        .All();
        }

        public void GravaServico(Servico servico)
        {
            ServicoRepository.Insert(servico);
            LetsPartyContext.SaveChanges();
        }

        public Servico BuscaPorId(Guid id)
        {
           return ServicoRepository.GetById(id);
        }

        public void EditarServico(Servico servico)
        {
            ServicoRepository.Update(servico);
            
        }
    }
}
