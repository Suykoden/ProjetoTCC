using LetsParty.AppService.Usuarios.DTO;
using LetsParty.Domain.Model.Atores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsParty.AppService.Usuarios
{
    public interface IUsuarioAppService
    {
        IQueryable<UsuarioDTO> RetornaUsuario();
        void Grava(Usuario usuario);
        bool AutenticarUsuario(Usuario usuario);
        Usuario ObtemUsuarioLogado();
        void Deslogar();
        Guid getIDUsuario();
        Usuario BuscaUsuarioPorID(Guid Id);
        void EditarUsuario(Usuario usuario);
        IEnumerable<Usuario> ListaUsuarios();
        string VerificaAdministrador(Guid id);
        IEnumerable<Usuario> BuscaUsuarioPorNome(string Nome);
    }
}
