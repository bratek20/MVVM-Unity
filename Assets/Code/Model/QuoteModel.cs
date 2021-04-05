using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuoteModel
{
    public string Symbol { get; private set; }
    public float Value { get; private set; }

    public QuoteModel(string symbol, float value)
    {
        Symbol = symbol;
        Value = value;
    }
}
