using OperationQuasarFire.Business.Interfaces;
using OperationQuasarFire.Model;
using OperationQuasarFire.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperationQuasarFire.Business.Services
{
    public class OperationBase: IOperationBase
    {
        private readonly IResponseService _responseService;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly IUtils _utils;
        private readonly ICommunication _communication;

        public OperationBase(IResponseService responseService, IExceptionHandler exceptionHandler, IUtils utils, ICommunication communication)
        {
            _responseService = responseService;
            _exceptionHandler = exceptionHandler;
            _utils = utils;
            _communication = communication;
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
            catch (OperationBaseException ex)
            {
                _responseService.Meta.Errors.Add(_exceptionHandler.GetMessage(ex));
                _responseService.SetResponse(false, MessagesEnum.HttpStateBadRequest, null);
                return _responseService;
            }
        }

        public async Task<IResponseService> SaveSateliteInformation(Satelite satelite)
        {
            try
            {
                if(_communication.ValidateSateliteName(satelite.Name))
                {
                    List<Satelite> satellites = await _utils.ReadInformationFromFile();
                    if (satellites.Count > 0)
                    {
                        if (satellites.Where(x => x.Name.Equals(satelite.Name)).Any())
                            throw new OperationBaseException($"Ya se tiene registrada la información para el satélite {satelite.Name}");
                        else
                            satellites.Add(satelite);
                    }
                    else
                        satellites.Add(satelite);

                    await _utils.WriteInformationInFile(satellites);
                    _responseService.SetResponse(true, MessagesEnum.HttpStateOk, "Información almacenada con éxito");
                    
                }
                return _responseService;
            }
            catch(OperationBaseException ex)
            {
                _responseService.Meta.Errors.Add(_exceptionHandler.GetMessage(ex));
                _responseService.SetResponse(false, MessagesEnum.HttpStateBadRequest, null);
                return _responseService;
            }
        }

        public async Task<IResponseService> TriangularPosition()
        {
            try
            {
                ShipResponse shirpResponse = new();
                List<Satelite> satellites = await _utils.ReadInformationFromFile();
                if (satellites.Count == 3)
                {
                    float[] coordinates = _utils.CalculatePosition(satellites);
                    shirpResponse.Position = new Position { X = coordinates[0], Y = coordinates[1] };
                    shirpResponse.Message = _utils.CreateMessage(satellites);
                    _utils.DeleteFile();
                }else
                    throw new OperationBaseException($"No existe suficie información para determinar la posición");

                _responseService.SetResponse(true, MessagesEnum.HttpStateOk, shirpResponse);
                return _responseService;
            }
            catch (OperationBaseException ex)
            {
                _responseService.Meta.Errors.Add(_exceptionHandler.GetMessage(ex));
                _responseService.SetResponse(false, MessagesEnum.HttpStateBadRequest, null);
                return _responseService;
            }
        }
    }

    public class OperationBaseException : Exception
    {
        public OperationBaseException(string message) : base(message)
        {
        }
    }
}
