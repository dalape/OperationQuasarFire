using OperationQuasarFire.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OperationQuasarFire.Business.Interfaces
{
    public interface IUtils
    {
        /// <summary>
        /// Calcula la posición de la nave teniendo en cuenta la información de los satélites 
        /// </summary>
        /// <param name="satellites">Lista del modelo satélite con la infromación de la distancia, mensaje y nombre</param>
        /// <returns>Arreglo de float de dos posiciones con las coordenadas de X y Y de la nave que envía el mensaje</returns>
        float[] CalculatePosition(List<Satelite> satellites);

        /// <summary>
        /// Construye el mensaje enviado por la nave teniendo en cuanta la información de los satélite
        /// </summary>
        /// <param name="satellites">Lista del modelo satélite con la infromación de la distancia, mensaje y nombre</param>
        /// <returns>cadena con el mensaje enviado por la nave</returns>
        string CreateMessage(List<Satelite> satellites);

        /// <summary>
        /// Lee la información del archivo plano con los datos de los satélites
        /// </summary>
        /// <returns>Lista del modelo satélite con la información de la distancia, mensaje, y nombre</returns>
        Task<List<Satelite>> ReadInformationFromFile();

        /// <summary>
        /// Escribe la información de los satélites en el archivo plano en formato Json
        /// </summary>
        /// <param name="satellites">Lista del modelo satélite con la infromación de la distancia, mensaje y nombre</param>
        Task WriteInformationInFile(List<Satelite> satellites);

        /// <summary>
        /// Elimina el archivo plano con la información de los satélite
        /// </summary>
        void DeleteFile();
    }
}
