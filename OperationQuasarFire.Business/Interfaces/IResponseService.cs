namespace OperationQuasarFire.Business.Interfaces
{
    public interface IResponseService
    {
        dynamic Result { get; set; }
        public dynamic Meta { get; set; }

        /// <summary>
        /// Asigna los diferentes valores para la construcción de la respuesta de la API
        /// </summary>
        /// <param name="state">estado de la petición true o false</param>
        /// <param name="httpStatus">Descripción del estado de la petición correcto o incorrecto teniendo en cuenta los respectivos códigos</param>
        /// <param name="result">Resultado de la petición con los elementos necesarios</param>
        /// <param name="totalItems">Total de items que retorna la petición en caso de retornar más de uno</param>
        void SetResponse(bool state, string httpStatus, dynamic result = null, int totalItems = 0);
    }
}