using System.Threading.Tasks;

namespace OperationQuasarFire.Business.Interfaces
{
    public interface IAuthentication
    {
        /// <summary>
        /// Obtiene el token de autorización para la ejecución del API
        /// </summary>
        /// <returns>IresponseService con resultado de la petición,Token y fecha de vencimiento del token</returns>
        Task<IResponseService> GetToken();

        /// <summary>
        /// Valida si el usuario y contraseña coinciden con los registrados en el aplicativo
        /// </summary>
        /// <param name="name">Nombre de usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <returns>booleano true cuando el usuario y la contraseña coinciden, false cuando el usuario y la contraseña no coinciden</returns>
        bool ValidateCredentials(string name, string password);
    }
}
