using ShoppingBasket.Logger.Common;
using System.Configuration;
using System.IO;

namespace ShoppingBasket.Logger
{
    public class Logger : ILogger
    {
        private readonly string _fileKeyword = "Logger.File";
        private readonly string FilePath;


        public Logger()
        {
            FilePath = ConfigurationManager.AppSettings[_fileKeyword];
        }

        public void Log(string message)
        {
            using (StreamWriter w = File.AppendText(FilePath))
            {
                w.WriteLine(message);
            }

        }
    }
}
