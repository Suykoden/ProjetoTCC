﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnTCC.Domain.Interfaces;
using slnTCC.Infra.Data.Contexto;

namespace slnTCC.Infra.Data.Repositories
{
    public class ReposistoryBase<TEntity>:IDisposable,IRepositorioBase<TEntity> where TEntity :class ////classe concreta que implementa a interface repositorio base e idisposable para que a mesma possa ser destruida
    {

        protected ProjectContext Db = new ProjectContext(); ///Instancia da minha classe implementada no meu contexto 



        public void add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);   ///Salva um tipo generico que será definido na hora inserção 
            Db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
