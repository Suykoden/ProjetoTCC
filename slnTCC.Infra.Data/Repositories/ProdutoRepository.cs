using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnTCC.Domain.Entities;
using slnTCC.Domain.Interfaces;

namespace slnTCC.Infra.Data.Repositories
{
    public class ProdutoRepository : ReposistoryBase<Produto>, IProdutoRepository
    {


        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return Db.Produtos.Where(p => p.Nome == nome);
        }
    }
}
