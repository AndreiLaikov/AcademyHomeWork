using UnityEngine;
using UnityEngine.UI;

public class PlaneSwitcher : MonoBehaviour
{
    public GameObject[] planes;
    private GameObject _activePlane;
    public GameObject activePlane
    {
        get { return _activePlane; }
        
    }

    public Button btnNext;
    public Button btnPrevious;

    private int index = 0;

    private void Start()
    {
        foreach (var plane in planes)
        {
            plane.SetActive(false);
        }

        _activePlane = planes[0];
        _activePlane.SetActive(true);

        btnNext.onClick.AddListener(Next);
        btnPrevious.onClick.AddListener(Prev);
    }

    public void Activate()
    {
        _activePlane.SetActive(false);
        _activePlane = planes[index];
        _activePlane.SetActive(true);
    }

    private void Next()
    {
        index++;
        if (index > planes.Length-1)
            index = 0;
        Activate();
        
    }

    private void Prev()
    {
        index--;
        if (index < 0)
            index = planes.Length-1;
        Activate();
    }
}
