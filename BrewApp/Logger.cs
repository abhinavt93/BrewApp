using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BrewApp
{
    public sealed class Logger
    {
        private Logger()
        {

        }

        private static Logger obj;

        public static Logger Instance()
        {
            if (obj == null)
                obj = new Logger();
            return obj;
        }

        public string filePath = "E:/inetpub/wwwroot/BrewApp/Logs/Error.log";
        public void Log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }           
        }
    }
    
}