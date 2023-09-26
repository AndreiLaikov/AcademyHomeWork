using UnityEngine;
using UnityEngine.UI;

public class TglsClick : LabelFiller
{
    public ToggleGroup tGroup;

    private void Start()
    {
        if (tGroup == null)
        {
            Debug.Log("Missing ref toggleGroup on " + gameObject.name);
            return;
        }
    }

        private void Update()
    {
        foreach (var tgl in tGroup.ActiveToggles())
        {
            Fill(tgl.name);
        }
    }
}
