namespace PrismTableDemo;

public class ViewModelStore
{
    private Dictionary<string, object> _viewModels = new Dictionary<string, object>();

    public T GetOrCreateViewModel<T>(string key) where T : new()
    {
        if (!_viewModels.ContainsKey(key))
        {
            _viewModels[key] = new T();
        }
        return (T)_viewModels[key];
    }
}

public class MyViewModel
{
    ViewModelStore viewModelStore = new ViewModelStore();
    
    public MyViewModel()
    {
        // 在加载View时
        var viewModel = viewModelStore.GetOrCreateViewModel<MyViewModel>("View1");
    }
}