using OperationQuasarFire.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OperationQuasarFire.Business.Interfaces
{
    public interface IOperationBase
    {
        Task<IResponseService> TriangularPosition(List<Satelite> satellites);
    }
}
