using UnityEngine;

public class Scaler : MonoBehaviour
{
    //Плавно увеличивается до заданного значения

    public int destScale = 2;

    void Start()
    {
        transform.localScale = Vector3.one;
    }
   
    void Update()
    {
        var scale = Vector3.one * destScale;
        transform.localScale = Vector3.Lerp(transform.localScale, scale, Time.deltaTime);
    }
}
