using log4net.Core;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;
        SerializableLogEvent _logEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

       

        public object Message => _loggingEvent.MessageObject;
        public object UserName => _loggingEvent.UserName;


    }
}
