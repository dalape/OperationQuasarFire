namespace OperationQuasarFire.Model.Enums
{
    public class MessagesEnum
    {
        public const string InvalidModel = "Modelo inválido";
        public const string HttpStateNotFound = "404 - Not Found";
        public const string HttpStateOk = "200 - Ok";
        public const string HttpStateAccepted = "202 - Accepted";
        public const string HttpStateBadRequest = "400 - Bad Request";
        public const string HttpStateUnauthorized = "401 - Unauthorized";
        public const string DbUpdateException = "Hubo un error al actualizar el modelo";
        public const string DbError = "Error en el motor de Base de Datos";
        public const string OwnError = "Error controlado o regla de negocio";
        public const string Error = "Error";
        public const string FatalError = "Error fatal";
        public const string AdminError = "Error fatal, por favor contactese con el administrador";
    }
}
