using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Domain.Model.Atores;
using LetsParty.AppService.Usuarios.DTO;
using LetsParty.Domain.Repository;
using LetsParty.Infra.Data.Context;

namespace LetsParty.AppService.Usuarios.DTO
{
   public  class BaseService<T>: IBaseService<T> where T : class
    {
       private IUsuarioRepository UsuarioRepository { get; set; }
        private ILetsPartyContext LetsPartyContext { get; set; }

        public BaseService(IUsuarioRepository usuarioRepository, ILetsPartyContext context)
        {
            UsuarioRepository = usuarioRepository;
            LetsPartyContext = context;
        }

        public void Insert(T item)
        {
            UsuarioRepository.InsertInsert(UsuarioDTO a);
            LetsPartyContext.SaveChanges();
        }
    }
}
