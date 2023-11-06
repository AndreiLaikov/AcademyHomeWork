using UnityEngine;

public class GameController : MonoBehaviour
{
    private MeshCalculator calculator;
    private MeshGenerator generator;
    private CuttingMeshCalculator cuttingCalculator;
    public Vector3 initialSize;
    public Vector3 initialPosition;
    public Vector3 startMovingPosition = new Vector3(-1.5f, 0, 0);

    private int count;
    private Vector3 currentSize;

    private Transform previousBlock;
    private Transform currentBlock;

    private void Start()
    {
        currentSize = initialSize;
        calculator = new MeshCalculator();
        generator = GetComponent<MeshGenerator>();
        cuttingCalculator = new CuttingMeshCalculator();

        previousBlock = CreateBlock(currentSize, initialPosition);
        RecalculateCollider(previousBlock, currentSize);

        count++;

        CreateMovingBlock();
    }

    public Transform CreateBlock(Vector3 size, Vector3 pos)
    {
        calculator.sizes = size;
        calculator.CalculateMesh();
        generator.GenerateMesh(calculator.vertices, calculator.triangles);
        return generator.InstantiateMesh(pos);
    }

    public void CreateMovingBlock()
    {
        currentBlock = CreateBlock(currentSize, startMovingPosition + Vector3.up * currentSize.y * count);
        currentBlock.gameObject.AddComponent<MeshMover>();
        RecalculateCollider(currentBlock, currentSize);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GenerateNewMeshes();
            CreateMovingBlock();
        }
    }

    void GenerateNewMeshes()
    {
        var data = cuttingCalculator.Calculate(previousBlock, currentBlock, currentSize);
        previousBlock = CreateBlock(data.sizeStatic, data.posStatic);

        var dynamicBlock = CreateBlock(data.sizeDynamic, data.posDynamic);
        dynamicBlock.gameObject.AddComponent<Rigidbody>();

        currentSize = data.sizeStatic;
        count++;

        RecalculateCollider(previousBlock, data.sizeStatic);
        RecalculateCollider(dynamicBlock, data.sizeDynamic);
        Destroy(currentBlock.gameObject);
    }

    void RecalculateCollider(Transform obj, Vector3 size)
    {
        obj.GetComponent<BoxCollider>().size = size;
    }

}
