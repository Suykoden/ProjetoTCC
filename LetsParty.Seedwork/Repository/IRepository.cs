using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace LetsParty.Seedwork.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        IQueryable<T> All();

        T GetById(Guid? id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(Guid entityId);

        IEnumerable<T> Listar();

        void UpdateSet(T entityOld, T entity);

    }
}
