using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternDemo
{
    public class SpecificObserver : IObserver
    {
        private readonly string specificData;

        public SpecificObserver(string specificData)
        {
            this.specificData = specificData;
        }

        public void Update(string data)
        {
            if (data == specificData)
            {
                Console.WriteLine($"SpecificObserver received data: {data}");
            }
        }
    }

}
