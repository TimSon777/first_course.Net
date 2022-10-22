using System;
using Microsoft.Extensions.Logging;

namespace hw10.Services.Logging
{
    public interface IExceptionHandler
    {
        void Handle(Exception e, LogLevel logLevel = LogLevel.Information);
    }
}