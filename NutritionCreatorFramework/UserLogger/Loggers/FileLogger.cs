using NutritionCreatorFramework.UserLogger.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework.UserLogger.Loggers
{
    internal class FileLogger : IUserLogger
    {
        private readonly string _path;

        public FileLogger(string path)
        {
            _path = path;
        }

        public void Log(string message)
        {
            try
            {
                using (var sw = new StreamWriter($"{_path}/errors.txt", true))
                {
                    sw.WriteLine(message);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
