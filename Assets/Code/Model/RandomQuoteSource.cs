using System;
using System.Collections;
using UnityEngine;

public class RandomQuoteSource : MonoBehaviour, IQuoteSource
{
    public event Action<QuoteModel> QuoteArrived = _ => { };

    public void Subscibe(string symbol)
    {
        StartCoroutine(SendQuotes(symbol));
    }

    IEnumerator SendQuotes(string symbol)
    {
        while (true)
        {
            var quote = new QuoteModel(symbol, UnityEngine.Random.Range(-100, 100));
            QuoteArrived.Invoke(quote);
            yield return new WaitForSeconds(1.5f);
        }
    }
}
