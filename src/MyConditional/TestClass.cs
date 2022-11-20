using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConditional
{
   
    public class TestClass
    {
        private List<string> _contents = new List<string>();

        public void AddItem(string content)
        {
            //Contract.Requires(content != null);
            //Contract.Ensures(!string.IsNullOrEmpty(content));
            Contract.Requires<ArgumentNullException>(content != null,"错误");
            _contents.Add(content);
        }
    }
}
