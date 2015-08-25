using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsParty.Domain.Model.Atores
{
    public class Comprador : Usuario
    {
        public int CPF { get; set; }
        public DateTime DataNascimento { get; set; }

        public void PesquisarAnuncios()
        {

            //Implementar pesquisa de anuncios 
        }

        public void GerarFeedBack()
        {

            ///Implementar geração de feeedbak
        }

        public void Gerenciapedido()
        {

            //Implementar envio de pedido para fornecedor
        }
    }
}
