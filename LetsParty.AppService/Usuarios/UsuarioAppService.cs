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

            // HttpCookie User = new HttpCookie("LetsPartyUser");
            //   HttpCookie Senha = new HttpCookie("LetsPartyAcess");
            FormsAuthentication.SetAuthCookie(usuario.email, true);
            //User.Value = usuario.email;
            //Senha.Value = usuario.senha;

            //User.Expires = DateTime.Now.AddDays(1);
            //Senha.Expires = DateTime.Now.AddDays(1);
            //HttpContext.Current.Response.Cookies.Add(User);
            //HttpContext.Current.Response.Cookies.Add(Senha);

            return true;

        }


        public Usuario ObtemUsuarioLogado()
        {
            //if ((HttpContext.Current.Request.Cookies["LetsPartyUser"].Value != null) && (HttpContext.Current.Request.Cookies["LetsPartyAcess"].Value != null))
            //{
            //    string User = HttpContext.Current.Request.Cookies["LetsPartyUser"].Value.ToString();
            //    string Senha = HttpContext.Current.Request.Cookies["LetsPartyAcess"].Value.ToString();

            //    var Valida = UsuarioRepository.All().SingleOrDefault(u => u.email == User && u.senha == Senha);
            //    return Valida;

            //}
            //else
            //{
            //    return null;
            //}

            string Login = HttpContext.Current.User.Identity.Name;
            if (Login == "")
            {
                return null;
            }
            else
            {
                var Valida = UsuarioRepository.All().SingleOrDefault(u => u.email == Login);
                return Valida;
            }


        }

        public void Deslogar()
        {
            FormsAuthentication.SignOut();
        }



    }
}
