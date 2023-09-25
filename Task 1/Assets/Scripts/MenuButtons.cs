using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (Button))]
public class MenuButtons : MonoBehaviour
{
    public GameObject CloseWindow;
    public GameObject OpenWindow;

    private Button btn;

    private void Start()
    {
        if (OpenWindow == null)
        {
            Debug.Log("Missing ref openedWindow on " + gameObject.name);
            return;
        }

        if (CloseWindow == null)
        {
            Debug.Log("Missing ref closedWindow on " + gameObject.name);
            return;
        }

        btn = GetComponent<Button>();
        btn.onClick.AddListener(() => OpenClose());
    }

    private void OpenClose()
    {
        OpenWindow.SetActive(true);
        CloseWindow.SetActive(false);
    }
}
