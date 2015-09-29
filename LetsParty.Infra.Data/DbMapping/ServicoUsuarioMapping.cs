using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using LetsParty.Domain.Model.Atores;

namespace LetsParty.Infra.Data.DbMapping
{
    public class ServicoUsuarioMapping : EntityTypeConfiguration<ServicoUsuario>
    {
        public ServicoUsuarioMapping()
        {
            HasKey(p => p.Id);

            ToTable("ServicoUsuario");
        } 
    }
}
