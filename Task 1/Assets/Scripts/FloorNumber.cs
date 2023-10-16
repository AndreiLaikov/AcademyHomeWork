using TMPro;
using UnityEngine;

public class FloorNumber : MonoBehaviour
{
    public int Number;
    public TMP_Text Label;


    private void Start()
    {
        Set();
    }

    private void Set()
    {
        Label.text = Number.ToString();
        gameObject.name = "Floor [" + Number + "]";
    }

    public void IncreaseNumber(int value)
    {
        Number += value;
        Set();
    }

    public void DecreaseNumber(int value)
    {
        Number -= value;
        Set();
    }
}
