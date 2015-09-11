using LetsParty.Domain.Repository;
using LetsParty.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.Domain.Model.Atores;
using LetsParty.AppService.Usuarios.DTO;

namespace LetsParty.AppService.Usuarios
{
    public class UsuarioAppService : IUsuarioAppService
    {

        private IUsuarioRepository UsuarioRepository { get; set; }
        private ILetsPartyContext LetsPartyContext { get; set; }

        public UsuarioAppService(IUsuarioRepository usuarioRepository, ILetsPartyContext context)
        {
            UsuarioRepository = usuarioRepository;
            LetsPartyContext = context;
        }

        public IQueryable<UsuarioDTO> RetornaUsuario()
        {
            return UsuarioRepository
                        .All()
                        .Select(p => new UsuarioDTO()
                        {
                            Id = p.Id,
                            Codigo = p.Codigo,
                            Nome = p.Nome
                        });
        }

        public void Grava(Usuario usuario)
        {
            UsuarioRepository.Insert(usuario);
            LetsPartyContext.SaveChanges();
        }

        public  bool AutenticarUsuario(Usuario usuario)
        {
            var Retorno = UsuarioRepository.All().Where(u => u.email == usuario.email);
            return (true);

        }

    }
}
