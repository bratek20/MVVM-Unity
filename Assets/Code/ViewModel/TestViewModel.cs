using System.Collections.Generic;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class TestViewModel : ViewModel
{
    private IQuoteSource _quoteSource;

    public TestViewModel(IQuoteSource quoteSource)
    {
        _quoteSource = quoteSource;
        _quoteSource.QuoteArrived += OnQuoteArrived;
    }

    [Binding]
    public string Symbol
    {
        get => _symbol;
        set
        {
            if (_symbol == value)
            {
                return;
            }

            _symbol = value;

            OnPropertyChanged("Symbol");
        }
    }
    private string _symbol;

    [Binding]
    public string LastSymbol
    {
        get => _lastSymbol;
        set
        {
            if (_lastSymbol == value)
            {
                return;
            }

            _lastSymbol = value;

            OnPropertyChanged("LastSymbol");
        }
    }
    private string _lastSymbol;



    [Binding]
    public ObservableList<QuoteViewModel> Items
    {
        get
        {
            return _items;
        }
    }
    private ObservableList<QuoteViewModel> _items = new ObservableList<QuoteViewModel>();
    private Dictionary<string, QuoteViewModel> _symbolToViewModel = new Dictionary<string, QuoteViewModel>();

    [Binding]
    public void Subscribe()
    {
        LastSymbol = Symbol;
        _quoteSource.Subscibe(Symbol);
    }

    private void OnQuoteArrived(QuoteModel model)
    {
        QuoteViewModel viewModel;
        if (_symbolToViewModel.TryGetValue(model.Symbol, out viewModel))
        {
            viewModel.Update(model);
        }
        else
        {
            viewModel = new QuoteViewModel(model);
            Items.Add(viewModel);
            _symbolToViewModel.Add(viewModel.Symbol, viewModel);
        }
    }
}
