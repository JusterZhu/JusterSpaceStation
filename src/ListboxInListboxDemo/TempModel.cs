using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListboxInListboxDemo
{
    public class TempModel
    {
        public string Title { get; set; }

        public string SubContent { get; set; }

        public ObservableCollection<SubTempModel> Contents { get; set; }
    }

    public class SubTempModel
    {

        public string SubContent { get; set; }

        public override string ToString()
        {
            return SubContent;
        }
    }
}
