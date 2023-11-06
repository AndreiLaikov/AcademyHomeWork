using UnityEngine;

public class MeshColor : MonoBehaviour
{

    public void SetColor(float addHueValue)
    {
        float add = (addHueValue % 36)/36;
        var material = GetComponent<MeshRenderer>().material;
        Color.RGBToHSV(material.color, out float hue, out float saturation, out float value);
        var color = Color.HSVToRGB(hue + add, saturation, value);

        material.color = color;
    }
}
