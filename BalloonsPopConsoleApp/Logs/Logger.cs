using log4net;

namespace BalloonsPopConsoleApp.Logs
{
    public class Logger : ILogger
    {
        private readonly ILog logger;

        public Logger()
        {
            this.logger = LogManager.GetLogger(typeof (Logger));
        }

        public void Log(string operation)
        {
            this.logger.Info(operation);
        }
    }
}
