using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.AppService.Usuarios.DTO;
using LetsParty.Domain.Model.Atores;

namespace LetsParty.AppService.Servicos
{
    public interface IServicoServices
    {
        IQueryable<Servico> RetornaServicos(bool ListaInativos);
        void GravaServico(Servico servico);
        Servico BuscaPorId(Guid id);
        void EditarServico(Servico servico);
    }
}
