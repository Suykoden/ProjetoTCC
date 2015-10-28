using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.AppService.Usuarios.DTO;
using LetsParty.Domain.Model.Atores;
using LetsParty.Domain.Repository;
using LetsParty.Domain.ViewModel;

namespace LetsParty.AppService.Eventos
{
    public interface IEventoService
    {
        void GravaEvento(Evento evento);
        IEnumerable<EventoViewModel> RetornaEventos(Guid Id);
        void EditarEvento(Evento evento);
        Evento BuscaPorId(Guid Id);
    }

}
