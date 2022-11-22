using System.Collections.Generic;
using System.Threading.Tasks;

namespace Msi.Data.Abstractions
{
    public interface ISeeder<IGuidEntity>
    {
        int Order { get; }

        IEnumerable<IGuidEntity> GetSeeds();

        Task Seed(IUnitOfWork unitOfWork);
    }
}
