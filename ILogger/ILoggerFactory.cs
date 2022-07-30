using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILogger
{
    public interface ILoggerFactory
    {
        IUserLogger Create(string type);
    }
}
