using System;

namespace OperationQuasarFire.Business.Interfaces
{
    public interface IExceptionHandler
    {
        /// <summary>
        /// Obtiene el mensaje de la excepción generada en el aplicativo
        /// </summary>
        /// <param name="Exception">Excepción generada</param>
        /// <returns>cadena con el mensaje de la excepción generada</returns>
        string GetMessage(Exception ex);
    }
}
