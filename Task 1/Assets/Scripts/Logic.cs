using UnityEngine;

public class Logic : MonoBehaviour
{
    public NewGenerator generator;
    public Vector3 size;
    public int count;
    private NewGenerator currentObject;
    private NewGenerator previousObject;
    private Vector3 spawnPoint = new Vector3(-6, 0, 0);

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
            CreateObj(currentObject.transform.position+size.y*Vector3.up, size);
        }
    }

    private void CreateObj(Vector3 pos, Vector3 newSize)
    {
        currentObject = Instantiate(generator, pos, Quaternion.identity);
        currentObject.sizes = newSize;
        currentObject.GenerateMesh();
        count++;
    }

    private void CalculateNewSize()
    {
        var delta = currentObject.transform.position - previousObject.transform.position;
        var pivot0 = previousObject.transform.position + delta / 2;
        var pivot1 = pivot0 - (size.x / 2) * Vector3.forward;
    }

    private void CreateNewBlock()
    {
        CreateObj(spawnPoint + Vector3.up * size.y * count, size);
    }
}
