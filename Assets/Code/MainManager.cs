using UnityEngine;
using Zenject;

public class MainManager : MonoBehaviour
{
    public TestView testViewPrefab;
    public Canvas mainCanvas;

    private void Start()
    {
        testViewPrefab.gameObject.SetActive(false);
        var testView = Instantiate(testViewPrefab, mainCanvas.transform);
        testViewPrefab.gameObject.SetActive(true);
        testView.gameObject.SetActive(true);
    }
}
