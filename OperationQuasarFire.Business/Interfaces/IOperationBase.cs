using OperationQuasarFire.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OperationQuasarFire.Business.Interfaces
{
    public interface IOperationBase
    {
        /// <summary>
        /// Triangula la posición de la nave teniendo en cuenta la distancia de los satélites y construye el mensaje enviado en los satéites
        /// </summary>
        /// <param name="satellites">Lista del modelo satélite con la información de los satélites</param>
        /// <returns>IresponseService con resultado de la petición,posición de la nave en coordenadas X y Y y mensaje decifrado</returns>
        Task<IResponseService> TriangularPosition(List<Satelite> satellites);

        /// <summary>
        /// Guarda la información del satélite enviado en un archivo plano
        /// </summary>
        /// <param name="satelite">Modelo satélite con la información de la distancia, nombre y mensaje</param>
        /// <returns>IresponseService con resultado de la petición y mensaje de estado del guardado de información del satélite</returns>
        Task<IResponseService> SaveSateliteInformation(Satelite satelite);

        /// <summary>
        /// Triangula la posición de la nave teniendo en cuenta la información de los satélites registrada en el archivo plano
        /// </summary>
        /// <returns>IresponseService con resultado de la petición,posición de la nave en coordenadas X y Y y mensaje decifrado</returns>
        Task<IResponseService> TriangularPosition();
    }
}
