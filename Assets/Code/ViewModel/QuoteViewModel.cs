using System.ComponentModel;
using UnityWeld.Binding;

[Binding]
public class QuoteViewModel : ViewModel
{
    public QuoteViewModel(QuoteModel model)
    {
        Update(model);
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
    public float Value
    {
        get => _value;
        set
        {
            if (_value == value)
            {
                return;
            }

            _value = value;

            OnPropertyChanged("Value");
        }
    }
    private float _value;

    public void Update(QuoteModel model)
    {
        Symbol = model.Symbol;
        Value = model.Value;
    }
}
