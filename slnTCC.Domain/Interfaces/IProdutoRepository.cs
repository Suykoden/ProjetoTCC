using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnTCC.Domain.Entities;

namespace slnTCC.Domain.Interfaces
{
    public interface IProdutoRepository: IRepositorioBase<Produto>
    {

        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
