using System;
using System.IO;
using log4net;

namespace Controls
{
    public static class LoggerFactory
    {
        static readonly Logger<global::Controls.FuzzySearchComboBox.FuzzySearchCombobox> Logger;
        static LoggerFactory()
        { 
            Logger = new Logger<global::Controls.FuzzySearchComboBox.FuzzySearchCombobox>();

            var configFile = new FileInfo("log4net.config");
            log4net.Config.XmlConfigurator.Configure(configFile);
        }

        public static ILogger GetLogger()
        {
            return Logger;
        }
    }

    public interface ILogger
    {
        void Debug(object message);
        void Debug(object message, Exception exception);
        void DebugFormat(string format, params object[] args);
        void Error(object message);
        void Error(object message, Exception exception);
        void ErrorFormat(string format, params object[] args);
        void Info(object message);
        void Info(object message, Exception exception);
        void InfoFormat(string format, params object[] args);
        void Warn(object message);
        void Warn(object message, Exception exception);
        void WarnFormat(string format, params object[] args);
    }

    public class Logger<T> : ILogger
    {
        public Logger()
        {
            _logger = LogManager.GetLogger(typeof (T));
        }

        public void Debug(object message)
        {
            _logger.Debug(message);
        }

        public void Debug(object message, Exception exception)
        {
            _logger.Debug(message, exception);
        }

        public void DebugFormat(string format, params object[] args)
        {
            _logger.DebugFormat(format, args);
        }

        public void Error(object message)
        {
            _logger.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            _logger.Error(message, exception);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            _logger.ErrorFormat(format, args);
        }

        public void Info(object message)
        {
            _logger.Info(message);
        }

        public void Info(object message, Exception exception)
        {
            _logger.Info(message, exception);
        }

        public void InfoFormat(string format, params object[] args)
        {
            _logger.InfoFormat(format, args);
        }

        public void Warn(object message)
        {
            _logger.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            _logger.Warn(message, exception);
        }

        public void WarnFormat(string format, params object[] args)
        {
            _logger.WarnFormat(format, args);
        }

        private readonly ILog _logger;
    }
}