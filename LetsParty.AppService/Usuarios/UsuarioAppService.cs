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



        public bool AutenticarUsuario(Usuario usuario)
        {
            var Valida = UsuarioRepository.All().SingleOrDefault(u => u.email == usuario.email && u.senha == usuario.senha);

            if (Valida == null)
                return false;

            FormsAuthentication.SetAuthCookie(usuario.Nome, true);
            return true;

        }

       
        public Usuario ObtemUsuarioLogado()
        {
            string Login = HttpContext.Current.User.Identity.Name;

            if (Login == "")
            {
                return null;
            }
            else
            {
                var Valida = UsuarioRepository.All().SingleOrDefault(u => u.email == Login && u.senha == Login);
                return Valida;
            }



        } 

       

        
    }
}
