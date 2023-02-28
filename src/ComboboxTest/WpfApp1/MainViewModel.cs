using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class TestModel {

        public string EN { get; set; }

        public string CH { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return EN;
        }
    }

    public class MainViewModel
    {
        private ObservableCollection<TestModel> _testCollection;

        public ObservableCollection<TestModel> TestCollection { get => _testCollection ?? (_testCollection = new ObservableCollection<TestModel>()); set => _testCollection = value; }

        public MainViewModel() {
            for (int i = 0; i < 50000; i++)
            {
                TestCollection.Add(new TestModel { EN = i + "EN" , CH = i + "CH" , Message = DateTime.Now.ToString() });
            }
        }
    }
}
