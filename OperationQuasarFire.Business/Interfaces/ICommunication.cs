namespace OperationQuasarFire.Business.Interfaces
{
    public interface ICommunication
    {
        /// <summary>
        /// Obtiene las coordenadas de los satélites dependiendo el nombre
        /// </summary>
        /// <param name="sateliteName">Nombre del satélite</param>
        /// <returns>Arreglo de dos posiciones float con las respectivas coordenadas del satélite </returns>
        float[] CoordinatesByName(string sateliteName);

        /// <summary>
        /// Valida si el satélite existe dependiendo el nombre
        /// </summary>
        /// <param name="sateliteName">Nombre del satélite</param>
        /// <returns>booleano true cuando el satélite existe</returns>
        bool ValidateSateliteName(string sateliteName);

        /// <summary>
        /// Obtiene las coordenadas de los satélites dependiendo la distancia
        /// </summary>
        /// <param name="distance">distancia del satélite</param>
        /// <returns>Arreglo de dos posiciones float con las respectivas coordenadas del satélite </returns>
        float[] GetLocation(float distance);

        /// <summary>
        /// Obtiene el mensaje de los satélites dependiendo el arreglo de mensajes enviados
        /// </summary>
        /// <param name="messages">arreglo con palabrar que conforman un mensaje</param>
        /// <returns>cadena con el mensaje del satélite decifrado</returns>
        string GetMessage(string[] messages);
    }
}
