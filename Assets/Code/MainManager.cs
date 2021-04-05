using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public TestView testViewPrefab;
    public Canvas mainCanvas;

    private void Start()
    {
        var quoteSource = new GameObject("RandomQuotes").AddComponent<RandomQuoteSource>();
        var testViewModel = new TestViewModel(quoteSource);

        testViewPrefab.gameObject.SetActive(false);
        var testView = Instantiate(testViewPrefab, mainCanvas.transform);
        testView.Setup(testViewModel);
        testViewPrefab.gameObject.SetActive(true);
        testView.gameObject.SetActive(true);
    }
}
