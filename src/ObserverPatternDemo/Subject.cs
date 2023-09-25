using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternDemo
{
    public class Subject
    {
        public event Action<string> DataChanged; // 声明事件

        public void NotifyObservers(string data)
        {
            DataChanged?.Invoke(data); // 触发事件
        }
    }

}
