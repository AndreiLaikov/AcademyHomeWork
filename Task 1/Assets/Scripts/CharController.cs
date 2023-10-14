using UnityEngine;

public class CharController : MonoBehaviour
{
    
    private SpriteRenderer _spriteRenderer;
    public SpriteRenderer Renderer
    {
        get { return _spriteRenderer ?? GetComponent<SpriteRenderer>(); }
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
