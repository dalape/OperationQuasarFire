using OperationQuasarFire.Business.Interfaces;
using OperationQuasarFire.Model;
using OperationQuasarFire.Model.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OperationQuasarFire.Business.Services
{
    public class OperationBase: IOperationBase
    {
        private readonly IResponseService _responseService;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly IUtils _utils;

        public OperationBase(IResponseService responseService, IExceptionHandler exceptionHandler, IUtils utils)
        {
            _responseService = responseService;
            _exceptionHandler = exceptionHandler;
            _utils = utils;
        }

        public async Task<IResponseService> TriangularPosition(List<Satelite> satellites)
        {
            try
            {
                ShipResponse shirpResponse = new();
                float[] coordinates = _utils.CalculatePosition(satellites);
                shirpResponse.Position = new Position { X = coordinates[0] , Y = coordinates[1] };
                shirpResponse.Message = _utils.CreateMessage(satellites);

                _responseService.SetResponse(true, MessagesEnum.HttpStateOk, shirpResponse);
                return _responseService;
            }
            catch (Exception ex)
            {
                _responseService.Meta.Errors.Add(_exceptionHandler.GetMessage(ex));
                _responseService.SetResponse(false, MessagesEnum.HttpStateBadRequest, null);
                return _responseService;
            }
        }
    }
}
