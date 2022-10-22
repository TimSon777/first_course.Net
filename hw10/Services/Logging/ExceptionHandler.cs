using System;
using hw10.Controllers;
using Microsoft.Extensions.Logging;

namespace hw10.Services.Logging
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<CalculatorController> _logger;
        private LogLevel LogLevel { get; set; }

        public ExceptionHandler(ILogger<CalculatorController> logger) 
            => _logger = logger;
        
        public void Handle(Exception e, LogLevel logLevel = LogLevel.Information)
        {
            LogLevel = logLevel;
            Handle((dynamic) e);
        }

        private void Handle(ArgumentException e) 
            => _logger.Log(LogLevel, e.Message + ": Пользователь передал не валидную строку");

        private void Handle(NullReferenceException e) 
            => _logger.Log(LogLevel, e.Message + ": Пользователь ничего не ввел");

        private void Handle(InvalidOperationException e) 
            => _logger.Log(LogLevel, e.Message + ": Пользователь передал неправильное выражение");
    }
}