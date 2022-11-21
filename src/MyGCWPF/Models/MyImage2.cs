using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGCWPF.Models
{
    internal class MyImage2
    {
        private long _size;

        /// <summary>
        /// 图片路径
        /// </summary>
        public string MyPath { get; set; }

        public MyImage2(long size)
        {
            _size = size;
            GC.AddMemoryPressure(_size);
        }

        public void Dispose() => GC.RemoveMemoryPressure(_size);
    }
}
