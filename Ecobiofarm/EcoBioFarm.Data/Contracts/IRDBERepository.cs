using System.Linq;

namespace EcoBioFarm.Data.Contracts
{
    public interface IRDBERepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> AllReadOnly();

        void Detach(T entoty);

        int SaveChanges();
    }
}
