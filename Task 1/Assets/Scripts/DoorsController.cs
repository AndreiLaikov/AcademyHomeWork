using UnityEngine;

public class DoorsController : MonoBehaviour
{
    public DoorsModel model;
    public Transform Anchor;

    public float MaxAngle;

    private Vector3 openRotation;
    private Quaternion target;

    private void Start()
    {
        openRotation = new Vector3(0, MaxAngle, 0);
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        Anchor.localRotation = Quaternion.RotateTowards(Anchor.localRotation, target, model.speed);
    }

    public void Open(Transform player)
    {
        var dir = transform.position - player.transform.position;
        var dot = Vector3.Dot(transform.forward, dir.normalized);
        var sign = (int)Mathf.Sign(dot);

        target = Quaternion.Euler(openRotation * sign);
    }

    public void Close()
    {
        target = Quaternion.Euler(Vector3.zero);
    }

}
