using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.AppService.Usuarios.DTO;
using LetsParty.Domain.Model.Atores;

namespace LetsParty.AppService.Usuarios
{
    public interface IBaseService<T> where T: class
    {
       void Insert(T entity);

    }
}
