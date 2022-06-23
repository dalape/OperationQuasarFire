using System;

namespace OperationQuasarFire.Business.Interfaces
{
    public interface IExceptionHandler
    {
        string GetMessage(Exception ex);
    }
}
