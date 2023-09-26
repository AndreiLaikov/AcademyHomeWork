using TMPro;
using UnityEngine;

public class LabelFiller : MonoBehaviour
{
    public TMP_Text label;

    private void Start()
    {
        if (label == null)
        {
            Debug.Log("Missing ref label on " + gameObject.name);
            return;
        }
    }

    protected void Fill(string name)
    {
        label.text = name;
    }
}
