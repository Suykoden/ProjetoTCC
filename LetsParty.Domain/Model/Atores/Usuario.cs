using LetsParty.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsParty.Domain.Model.Atores
{
    public class Usuario : EntityWithCodeAndName
    {
        public string senha { get; set; }
        public string email { get; set; }
        public DateTime DataCadastro { get; set; }




        public void EfetuarLogin()
        {

            //Implementar login aqui 
        }

        public void GerenciarConta()
        {

            //Implementar gerenciamento de contas 
        }

        public void GeraRelatorio()
        {

            ///Implementar geração de relatórios ,somente para fornecedor e administrador do sistema 



        }
        public void GerenciarMensagem()
        {

            //Implementar gerenciamento de mensagens 
        }


    }
}
