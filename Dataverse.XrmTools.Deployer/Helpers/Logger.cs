using System;
using Dataverse.XrmTools.Deployer.Enums;

namespace Dataverse.XrmTools.Deployer.Helpers
{
    public class Logger
    {
        public event EventHandler<LoggerEventArgs> OnLog;
        public event EventHandler<LoggerEventArgs> OnOutput;

        internal virtual void Log(LogLevel level, string message)
        {
            var args = new LoggerEventArgs
            {
                Level = level,
                Message = message
            };

            OnLog?.Invoke(this, args);
        }

        internal virtual void Output(LogLevel level, string message)
        {
            var args = new LoggerEventArgs
            {
                Level = level,
                Message = message
            };

            OnOutput?.Invoke(this, args);
        }
    }

    public class LoggerEventArgs : EventArgs
    {
        public LogLevel Level { get; set; }
        public string Message { get; set; }
    }
}
