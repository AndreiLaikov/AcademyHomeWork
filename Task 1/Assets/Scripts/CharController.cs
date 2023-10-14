using UnityEngine;

public class CharController : MonoBehaviour
{
    
    private SpriteRenderer renderer;
    public SpriteRenderer Renderer
    {
        get { return renderer ?? GetComponent<SpriteRenderer>(); }
    }

    void OnDirectionChange()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Renderer.flipX = !Renderer.flipX;
        }
    }

    private void Update()
    {
        OnDirectionChange();
    }
}
