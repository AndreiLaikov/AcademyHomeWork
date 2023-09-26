using UnityEngine;
using UnityEngine.UI;

public class BtnsClick : LabelFiller
{
    public Button[] btns;

    private void OnEnable()
    {
        foreach (var btn in btns)
        {
            if (btn == null)
            {
                Debug.Log("Missing ref buttons on " + gameObject.name);
                return;
            }
            btn.interactable = true;
        }   
    }

    private void Start()
    {
        foreach (var btn in btns)
        {
            if (btn == null)
            {
                Debug.Log("Missing ref buttons on " + gameObject.name);
                return;
            }

            btn.onClick.AddListener(() => Fill(btn.name));
        }
    }

}
