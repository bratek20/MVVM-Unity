using UnityEngine;
using UnityWeld.Binding;
using Zenject;

public class View<TViewModel> : MonoBehaviour, IViewModelProvider where TViewModel : ViewModel
{
    private TViewModel _viewModel;
    private bool _callOnEnableAfterConstruct;

    [Inject]
    private void Construct(TViewModel viewModel)
    {
        _viewModel = viewModel;

        if (_callOnEnableAfterConstruct)
        {
            OnEnable();
        }
    }

    private void OnEnable()
    {
        if (_viewModel == null)
        {
            _callOnEnableAfterConstruct = true;
            return;
        }

        _viewModel.AttachEvents();    
    }

    private void OnDisable()
    {
        _viewModel.DetachEvents();
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
