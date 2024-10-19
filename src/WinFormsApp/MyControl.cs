using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class MyControl : DataGridView
    {
        private Pen _selectionPen;

        public  MyControl() 
        {
            //_selectionPen = new(Application.SystemColors.WindowText, 2);
            //Parent.DarkMode = DarkMode.Disabled;
            //DarkMode.Inherits = true;
        }
    }
}
