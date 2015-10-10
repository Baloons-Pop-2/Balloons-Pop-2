// <copyright  file="Logger.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Logs
{
    using BalloonsPop.Logs;
    using log4net;

    /// <summary>
    /// The object logs information in a file or an object.
    /// </summary>
    public class Logger : ILogger
    {
        /// <summary>
        /// An ILog instance.
        /// </summary>
        private readonly ILog logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        public Logger()
        {
            this.logger = LogManager.GetLogger(typeof(Logger));
        }

        /// <summary>
        /// Logs the passed string.
        /// </summary>
        /// <param name="operation">The string to be logged.</param>
        public void Log(string operation)
        {
            this.logger.Info(operation);
        }
    }
}
