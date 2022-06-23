using OperationQuasarFire.Business.Interfaces;
using OperationQuasarFire.Model;

namespace OperationQuasarFire.Business.Services
{
    public class ResponseService : IResponseService
    {
        public dynamic Result { get; set; }
        private Meta meta = new();
        public dynamic Meta
        {
            get { return meta; }
            set { meta = value; }
        }

        public ResponseService()
        {
            Meta.Status = false;
        }

        public void SetResponse(bool estado, string httpStatus, dynamic elements = null, int totalItems = 0)
        {
            Meta.Status = estado;
            Meta.HttpStatus = httpStatus;
            Result = totalItems.Equals(0) ? new { elements } : Result = new { elements, totalItems };
        }
    }
}