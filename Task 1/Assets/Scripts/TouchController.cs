using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 sumVec;
    public GameObject arrow;

    public CharacterMove character;

    private float halfScreen;

    private void Start()
    {
        halfScreen = Screen.width / 2;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                startPos = Input.touches[0].position;
            }
            if (Input.touches[0].phase == TouchPhase.Moved && Input.touches[0].position.x < halfScreen)
            {
                sumVec = (Input.touches[0].position - startPos).normalized;
                arrow.transform.up = sumVec;

               // startPos = Input.touches[0].position;
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(sumVec.x, sumVec.y,0), 5*Time.deltaTime);
            }
           
        }
        else
        {
            sumVec = Vector2.zero;
        }
        character.MoveWithTouch(sumVec);



    }
}
