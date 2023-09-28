using System;
using UnityEngine;
using UnityEngine.UI;

public class MatColorChanger : MonoBehaviour
{
    public PlaneSwitcher switcher;

    private Color targetColor;
    public Button[] btns;
   

    public void Start()
    {
        foreach (var btn in btns)
        {
            btn.onClick.AddListener(()=> ColorSwitch(btn));
        }
    }

    private void ColorSwitch(Button btn)
    {
        targetColor = btn.targetGraphic.color;
        switcher.activePlane.GetComponent<MeshRenderer>().material.color = targetColor;
    }
}
