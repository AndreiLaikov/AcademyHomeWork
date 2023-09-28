using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public MeshRenderer render;

    private Color baseColor;

    private void Awake()
    {
        render = GetComponent<MeshRenderer>();
        baseColor = render.material.color;
    }

    public void ChangeColor(Color color)
    {
        render.material.color = color;
    }

    public void Reset()
    {
        render.material.color = baseColor;
    }
}
