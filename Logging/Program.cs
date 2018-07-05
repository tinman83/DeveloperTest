using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Logger logger = new Logger("testlooger.log", Logger.Level.Info);

                logger.Debug("Debug Message Test");
                logger.Info("Info Message Test");
                logger.Error("Error Message Test");

                logger.Info("Demo of logger starting");

                for (int i = 0; i < 5; i++)
                    logger.Info($"i = {i}");

                logger.Info("Demo of logger complete");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }


    public class Logger
    {
        private string _fileName;
        public Logger(string fileName, Level level)
        {
            _fileName = fileName;
            WriteToFile("Logger", "Initialised");
        }

        public enum Level
        {
            Debug,
            Info,
            Error
        }

        private void WriteToFile(string level, string message)
        {
            string path =_fileName;
                using (System.IO.StreamWriter file = (File.Exists(path)) ? File.AppendText(path) : File.CreateText(path))
                {
                    file.WriteLine("{0} {1} {2}",DateTime.Now.ToString("yyyy.MM.dd hh:mm:ss"),level,message);
                }

        }
        public void Debug(string message)
        {
            WriteToFile("DEB", message);
        }
        public void Info(string message)
        {
            WriteToFile("INF", message);
        }
        public void Error(string message)
        {
            WriteToFile("ERR", message);
        }

        ~Logger()
        {
            WriteToFile("Logger", "Destroyed");
        }
    }
}
