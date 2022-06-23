using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationQuasarFire.Business.Interfaces
{
    public interface IAuthentication
    {
        Task<IResponseService> GetToken();
        bool ValidateCredentials(string name, string password);
    }
}
