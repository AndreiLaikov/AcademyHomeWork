using UnityEngine;
using UnityEngine.UI;

public class ButtonBack : MonoBehaviour
{
    public GameObject mainWindow;
    public Button btn;
    
    public void Start()
    {
        if(mainWindow == null)
        {
            Debug.Log("Missing ref Main Window on " +gameObject.name);
            return;
        }

        if (btn == null)
        {
            Debug.Log("Missing ref button back on " + gameObject.name);
            return;
        }

        btn.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
            mainWindow.SetActive(true);
        });
    }
}
