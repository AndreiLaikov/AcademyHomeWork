using System;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private MeshCalculator calculator;
    private MeshGenerator generator;
    private CuttingMeshCalculator cuttingCalculator;

    public Transform PreviousBlock { get; private set; }
    private Transform currentBlock;

    private GameObject meshParent;

    public int Count { get; private set; }

    private Vector3 currentSize;

    public void Init(Vector3 initSize, Vector3 initPos)
    {
        if(meshParent != null)
        {
            Destroy(meshParent);
        }

        meshParent = new GameObject("Parent");
        Count = 1;
        calculator = new MeshCalculator();
        generator = GetComponent<MeshGenerator>();
        cuttingCalculator = new CuttingMeshCalculator();

        currentSize = initSize;
        PreviousBlock = CreateBlock(currentSize, initPos);
        RecalculateCollider(PreviousBlock, currentSize);

        EventManager.GameEnding += OnGameEnding;
    }

    public void GenerateStartingBox(Vector3 size,Vector3 initPos)
    {
        var block = CreateBlock(size, initPos);
        RecalculateCollider(block, size);
    }

    private void OnGameEnding()
    {
        currentBlock.GetComponent<MeshMover>().isMoving = false;
        currentBlock.gameObject.AddComponent<Rigidbody>();
    }

    private Transform CreateBlock(Vector3 size, Vector3 pos)
    {
        calculator.sizes = size;
        calculator.CalculateMesh();
        generator.GenerateMesh(calculator.vertices, calculator.triangles);
        return generator.InstantiateMesh(pos,meshParent.transform);
    }

    public void CreateMovingBlock(Vector3 startPos)
    {
        currentBlock = CreateBlock(currentSize, startPos + Vector3.up * currentSize.y * Count);
        currentBlock.gameObject.AddComponent<MeshMover>();
        RecalculateCollider(currentBlock, currentSize);
        currentBlock.GetComponent<MeshColor>().SetColor(Count);
    }

    public void GenerateNewMeshes()
    {
        var data = cuttingCalculator.Calculate(PreviousBlock, currentBlock, currentSize);

        if (data.sizeStatic.x < 0)
        {
            EventManager.OnGameEnding();
            return;
        }

        PreviousBlock = CreateBlock(data.sizeStatic, data.posStatic);
        currentSize = data.sizeStatic;
        RecalculateCollider(PreviousBlock, data.sizeStatic);
        PreviousBlock.GetComponent<MeshColor>().SetColor(Count);

        var dynamicBlock = CreateBlock(data.sizeDynamic, data.posDynamic);
        dynamicBlock.gameObject.AddComponent<Rigidbody>();
        dynamicBlock.GetComponent<MeshColor>().SetColor(Count);
        RecalculateCollider(dynamicBlock, data.sizeDynamic);

        Destroy(currentBlock.gameObject);

        Count++;
        EventManager.OnPlaceSuccess(Count);
    }

    void RecalculateCollider(Transform obj, Vector3 size)
    {
        obj.GetComponent<BoxCollider>().size = size;
    }
}
