using LetsParty.Infra.Data.Context;
using LetsParty.Seedwork;
using LetsParty.Seedwork.Repository;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;


namespace LetsParty.Infra.Data.Repository
{


    public abstract class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {

        private DbContext Context { get; set; }
        private DbSet<T> Base { get; set; }

        public RepositoryBase(ILetsPartyContext currentContext)
        {
            Context = currentContext.Context;
            Base = currentContext.Context.Set<T>();
        }

        public RepositoryBase()
        {
            // TODO: Complete member initialization
        }

        public IQueryable<T> All()
        {
            return Base.AsQueryable();
        }

        public T GetById(Guid? id)
        {
            if (!id.HasValue) return null;

            return All().AsQueryable().FirstOrDefault(p => p.Id == id.Value);
        }

      
        public void Insert(T entity)
        {
            Base.Add(entity);
        }

        public void Update(T entity)
        {
            Context.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (entity == null) throw new NullReferenceException("Entidade que deveria ser excluida não foi passada para o método do repositorio");

            Base.Remove(entity);
        }

        public void Delete(Guid entityId)
        {
            var entity = GetById(entityId);
            if (entity == null) throw new NullReferenceException("Não foi possivel encontrar o registro com chave informada.");

            Delete(entity);
        }

        public IEnumerable<T> Listar()
        {
            return Context.Set<T>().AsEnumerable();
        }

        public void UpdateSet(T entityOld, T entity)
        {
            Context.Entry(entityOld).CurrentValues.SetValues(entity);
        }
    }


}


