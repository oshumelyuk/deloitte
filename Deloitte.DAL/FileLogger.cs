using System;
using System.IO;
using System.Threading.Tasks;
using Deloitte.DAL.Interfaces;
using Microsoft.Practices.TransientFaultHandling;

namespace Deloitte.DAL
{
    public class FileLogger : ILogger
    {
        public Task LogAsync(Exception exception)
        {
            Guard.ArgumentNotNull(exception, nameof(exception));

            var message = string.Format("{0}\t{1}\t{2}\t{3}", DateTime.Now, "High", exception.Message, exception.StackTrace);
            return WriteFormattedMessageAsync(message);
        }

        public Task LogAsync(string message)
        {
            Guard.ArgumentNotNullOrEmptyString(message, nameof(message));

            var formattedMessage = string.Format("{0}\t{1}\t{2}", DateTime.Now, "High", message);
            return WriteFormattedMessageAsync(formattedMessage);
        }

        private Task WriteFormattedMessageAsync(string message)
        {
            var logsAbsolutePath = DeloitteHostingEnvironment.Get(logsFilePath);
            lock (_locker)
            {
                if (!File.Exists(logsAbsolutePath))
                {
                    File.Create(logsAbsolutePath);
                }
                File.AppendAllText(logsFilePath, message, System.Text.Encoding.UTF8);
            }
            return Task.CompletedTask;
        }

        private const string logsFilePath = "\\data\\logs.txt";
        private static readonly object _locker = new object();
    }
}
