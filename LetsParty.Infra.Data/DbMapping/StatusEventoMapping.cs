using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using LetsParty.Domain.Model.Atores;

namespace LetsParty.Infra.Data.DbMapping
{
    public class StatusEventoMapping : EntityTypeConfiguration<StatusEvento>
    {
        public StatusEventoMapping()
        {
            HasKey(p => p.Id);

            ToTable("StatusEvento");
        }
    }
}
