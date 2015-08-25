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

    }
}
