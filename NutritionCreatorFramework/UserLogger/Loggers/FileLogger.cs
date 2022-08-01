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
        public void Log(string message)
        {
            try
            {
                using (var sw = new StreamWriter("errors.txt", true))
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
