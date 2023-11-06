using UnityEngine;

public class Logic : MonoBehaviour
{
    public NewGenerator generator;
    public Vector3 size;
    public int count;
    private NewGenerator currentObject;
    private NewGenerator previousObject;
    private Vector3 spawnPoint = new Vector3(-1.5f, 0, 0);

    private void Start()
    {
        CreateObj(transform.position, size);
        previousObject = currentObject;
        currentObject.GetComponent<MeshMover>().isMoving = false;
        CreateNewBlock();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateDoubleMesh();
            CreateNewBlock();
        }
    }

    private void CreateObj(Vector3 pos, Vector3 newSize)
    {
        currentObject = Instantiate(generator, pos, Quaternion.identity);
        currentObject.sizes = newSize;
        currentObject.GenerateMesh();
        count++;
        currentObject.gameObject.AddComponent<MeshMover>();
    }

    private void CreateNewBlock()
    {
        CreateObj(spawnPoint + Vector3.up * size.y * count, size);
    }

    void CreateDoubleMesh()
    {
        var deltaX = currentObject.transform.position.x - previousObject.transform.position.x;
        var sign = Mathf.Sign(deltaX);

        var pivot0 = previousObject.transform.position.x + deltaX / 2;
        var pivot1 = previousObject.transform.position.x + sign * size.x / 2 + deltaX / 2;

        var pos0 = new Vector3(pivot0, currentObject.transform.position.y, currentObject.transform.position.z);
        var pos1 = new Vector3(pivot1, currentObject.transform.position.y, currentObject.transform.position.z);

        var newSize0 = size.x - Mathf.Abs(deltaX);
        var newSize1 = Mathf.Abs(deltaX);

        if (newSize0 < 0)
        {
            Debug.Log("Min");
            return;
        }

        previousObject = Instantiate(generator, pos0, Quaternion.identity);
        previousObject.sizes = new Vector3(newSize0, size.y, size.z);
        previousObject.GenerateMesh();

        var fallingObject = Instantiate(generator, pos1, Quaternion.identity);
        fallingObject.sizes = new Vector3(newSize1, size.y, size.z);
        fallingObject.GenerateMesh();
        fallingObject.gameObject.AddComponent<Rigidbody>();

        size = previousObject.sizes;

        Destroy(currentObject.gameObject);

    }

}
