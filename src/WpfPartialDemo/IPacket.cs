using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPartialDemo
{
    public interface IPacket
    {
        void Head();

        void Body();

        void Foot();

        //...省略其他定义
    }
}
