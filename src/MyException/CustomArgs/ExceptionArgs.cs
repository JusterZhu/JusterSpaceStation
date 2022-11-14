using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyException.CustomArgs
{
    [Serializable]
    public abstract class ExceptionArgs
    {
        public virtual string Message { get { return String.Empty; } }
    }
}
