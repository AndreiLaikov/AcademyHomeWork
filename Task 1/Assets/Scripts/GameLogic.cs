using System;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private MeshCalculator calculator;
    private MeshGenerator generator;
    private CuttingMeshCalculator cuttingCalculator;

    private Transform previousBlock;
    private Transform currentBlock;

    private GameObject meshParent;

    public int Count 
    {
        get { return count; }
        private set { count = value; }
    }
    private int count;

    private Vector3 currentSize;

    public void Init(Vector3 initSize, Vector3 initPos)
    {
        if(meshParent != null)
        {
            Debug.Log("Destroy");
            Destroy(meshParent);
        }

        meshParent = new GameObject("Parent");
        count = 1;
        calculator = new MeshCalculator();
        generator = GetComponent<MeshGenerator>();
        cuttingCalculator = new CuttingMeshCalculator();

        currentSize = initSize;
        previousBlock = CreateBlock(currentSize, initPos);
        RecalculateCollider(previousBlock, currentSize);

        EventManager.GameEnding += OnGameEnding;
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
        currentBlock = CreateBlock(currentSize, startPos + Vector3.up * currentSize.y * count);
        currentBlock.gameObject.AddComponent<MeshMover>();
        RecalculateCollider(currentBlock, currentSize);
        currentBlock.GetComponent<MeshColor>().SetColor(count);
    }

    public void GenerateNewMeshes()
    {
        var data = cuttingCalculator.Calculate(previousBlock, currentBlock, currentSize);

        if (data.sizeStatic.x < 0)
        {
            EventManager.OnGameEnding();
            return;
        }

        previousBlock = CreateBlock(data.sizeStatic, data.posStatic);
        currentSize = data.sizeStatic;
        RecalculateCollider(previousBlock, data.sizeStatic);
        previousBlock.GetComponent<MeshColor>().SetColor(count);

        var dynamicBlock = CreateBlock(data.sizeDynamic, data.posDynamic);
        dynamicBlock.gameObject.AddComponent<Rigidbody>();
        dynamicBlock.GetComponent<MeshColor>().SetColor(count);
        RecalculateCollider(dynamicBlock, data.sizeDynamic);

        Destroy(currentBlock.gameObject);

        count++;
        EventManager.OnPlaceSuccess(count);
    }

    void RecalculateCollider(Transform obj, Vector3 size)
    {
        obj.GetComponent<BoxCollider>().size = size;
    }
}
