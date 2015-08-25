using System.Data.Entity;

namespace LetsParty.Infra.Data.Context
{
    public interface ILetsPartyContext
    {
        DbContext Context { get; }

        void SaveChanges();
        
    }
}