using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternDemo
{
    public interface IObserver
    {
        void Update(string data); // 观察者只关注特定数据
    }

}
