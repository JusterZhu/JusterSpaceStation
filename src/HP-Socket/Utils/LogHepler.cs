using System.Reflection;
using log4net;

namespace X.NetCore.Utils
{
    public class LogHepler
    {
        public static ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    }
}
