using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 sumVec;
    public GameObject arrow;

    private float halfString;

    private void Start()
    {
        halfString = Screen.width / 2;
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].position.x < halfString)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                startPos = Input.touches[0].position;
            }
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                sumVec = (Input.touches[0].position - startPos).normalized;
                arrow.transform.up = sumVec;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(sumVec.x, sumVec.y,0), 5*Time.deltaTime);
            }
        }
    }
}
