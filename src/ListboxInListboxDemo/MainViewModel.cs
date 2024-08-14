using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ListboxInListboxDemo
{
    public class MainViewModel : ObservableObject
    {
        private string _currentContent;
        private ObservableCollection<TempModel> _tempModels;

        public ObservableCollection<TempModel> TempModels { get => _tempModels ?? (_tempModels = new ObservableCollection<TempModel>()); }

        public string CurrentContent 
        { 
            get => _currentContent;
            set => SetProperty(ref _currentContent , value); 
        }

        public MainViewModel() 
        {
            for (int i = 0; i < 2; i++)
            {
                TempModel model = new TempModel();
                model.Title = $"{i}Title" + DateTime.Now.ToString();
                model.Contents = new ObservableCollection<SubTempModel> 
                {
                     new SubTempModel { SubContent =  $"Content{Random.Shared.NextDouble()}"},
                     new SubTempModel { SubContent =  $"Content{Random.Shared.NextDouble()}"}
                };
                TempModels.Add(model);
            }
        }
    }
}
