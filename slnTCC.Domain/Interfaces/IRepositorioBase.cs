using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slnTCC.Domain.Interfaces
{
   public  interface IRepositorioBase<Tentity> where Tentity:class      ///Repositório Base,criada,pois   O MVC não se comunica com a minha infra, recebo uma lista de objetos genericos e trato elas como classes
    {                                                            //No repositório basicamente escrevo os cruds que serão usados no projeto 

        void add(Tentity obj);  ///Insert

        Tentity GetById(int id); 
        
        IEnumerable<Tentity> GetAll();

        void Update(Tentity obj);

        void Remove(Tentity obj);

        void Dispose();


    }
}
