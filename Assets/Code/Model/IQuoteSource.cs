using System;

public interface IQuoteSource
{
    void Subscibe(string symbol);

    event Action<QuoteModel> QuoteArrived;
}
