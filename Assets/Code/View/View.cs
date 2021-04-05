using UnityEngine;
using UnityWeld.Binding;

public class View<TViewModel> : MonoBehaviour, IViewModelProvider
{
    private TViewModel _viewModel;

    public void Setup(TViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public object GetViewModel()
    {
        return _viewModel;
    }

    public string GetViewModelTypeName()
    {
        return typeof(TViewModel).Name;
    }
}
