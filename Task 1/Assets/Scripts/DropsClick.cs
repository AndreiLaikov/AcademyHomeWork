using TMPro;
using UnityEngine;

public class DropsClick : LabelFiller
{
    public TMP_Dropdown drop;

    private void Start()
    {
        if (drop == null)
        {
            Debug.Log("Missing ref dropdown on " + gameObject.name);
            return;
        }

        drop.onValueChanged.AddListener(delegate
        {
            Fill(drop.captionText.text);
        });
    }
}