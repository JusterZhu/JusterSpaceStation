using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager
{
    internal class Test
    {
        public delegate void BoilHandle(object obj ,EventArgs eventArgs);
        public event BoilHandle BoilEvent;//封装了委托

        public void Test1() 
        {
            BoilEvent += Program_BoilEvent;
            GeneralEventManager.Instance.AddListener<BoilHandle>(BoilEvent);
            GeneralEventManager.Instance.Dispatch<BoilHandle>(this, new EventArgs());
        }

        private void Program_BoilEvent(object obj ,EventArgs eventArgs)
        {
            Console.WriteLine(1);
        }
    }
}
