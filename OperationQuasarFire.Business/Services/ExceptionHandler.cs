using Microsoft.Extensions.Logging;
using OperationQuasarFire.Business.Interfaces;
using OperationQuasarFire.Model.Enums;
using System;

namespace OperationQuasarFire.Business.Services
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(ILogger<ExceptionHandler> logger) => _logger = logger;

        public string GetMessage(Exception ex)
        {
            if (ex is ApplicationException applicationEx)
            {
                _logger.LogInformation(MessagesEnum.OwnError, ex, ex.Message.ToString());
                return ex.Message;
            }

            if (ex != null)
            {
                return ex.Message;
            }

            _logger.LogCritical(MessagesEnum.FatalError, ex, $"[InnerException: {ex.InnerException}][StackTrace: {ex.StackTrace}]");

            return MessagesEnum.AdminError;
        }
    }
}