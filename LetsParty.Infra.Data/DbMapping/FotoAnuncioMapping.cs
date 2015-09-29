using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using LetsParty.Domain.Model.Atores;

namespace LetsParty.Infra.Data.DbMapping
{
    public class FotoAnuncioMapping : EntityTypeConfiguration<FotoAnuncio>
    {
        public FotoAnuncioMapping()
        {
            HasKey(p => p.Id);

            ToTable("FotoAnuncio");
        } 
    }
}
