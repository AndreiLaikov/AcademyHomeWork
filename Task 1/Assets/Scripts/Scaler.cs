using UnityEngine;

public class Scaler : MonoBehaviour
{
    public int destScale = 2;

    private Vector3 scale;

    void Start()
    {
        transform.localScale = Vector3.one;
    }
   
    void Update()
    {
        scale = Vector3.one * destScale;

        transform.localScale = Vector3.Lerp(transform.localScale,scale,Time.deltaTime);
    }
}
