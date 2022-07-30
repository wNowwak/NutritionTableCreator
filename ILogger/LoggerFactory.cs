using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILogger
{
    public class LoggerFactory : ILoggerFactory
    {
        public IUserLogger Create(string type)
        {
            switch (type)
            {
                case "file":
                default:
                    return new FileLogger();
            }
        }
    }
}
