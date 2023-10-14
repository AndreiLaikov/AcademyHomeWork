using UnityEngine;

public class CharController : MonoBehaviour
{
    public static float Speed = 1;
    public static bool isLeft;

    private string AnimatorSpeedMultiplier = "SpeedMultiplier";

    private SpriteRenderer _spriteRenderer;
    public SpriteRenderer Renderer
    {
        get { return _spriteRenderer ?? GetComponent<SpriteRenderer>(); }
    }

    private Animator animController;

    private void Start()
    {
        animController = GetComponent<Animator>();
    }

    void OnDirectionChange()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Renderer.flipX = !Renderer.flipX;
            isLeft = !isLeft;
        }
    }

    public void ChangeSpeed()
    {
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            Speed += 1;
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            Speed -= 1;
        }

        Speed = Mathf.Clamp(Speed, 1, 20);
        animController.SetFloat(AnimatorSpeedMultiplier, Speed);
    }

    private void Update()
    {
        OnDirectionChange();
        ChangeSpeed();
    }
}
