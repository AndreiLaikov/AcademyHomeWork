using UnityEngine;

public class CuttingMeshCalculator
{
    public struct MeshesData
    {
        public Vector3 posStatic;
        public Vector3 posDynamic;
        public Vector3 sizeStatic;
        public Vector3 sizeDynamic;
    }

    public MeshesData Calculate(Transform prevBlock,Transform curBlock, Vector3 size)
    {
        MeshesData data = new MeshesData();
        var deltaX = curBlock.transform.position.x - prevBlock.transform.position.x;
        var sign = Mathf.Sign(deltaX);

        var pivotStatic = prevBlock.position.x + deltaX / 2;
        var pivotDynamic = prevBlock.position.x + sign * size.x / 2 + deltaX / 2;

        data.posStatic = new Vector3(pivotStatic, curBlock.position.y, curBlock.position.z);
        data.posDynamic = new Vector3(pivotDynamic, curBlock.position.y, curBlock.position.z);

        data.sizeStatic = new Vector3(size.x - Mathf.Abs(deltaX),size.y,size.z);
        data.sizeDynamic = new Vector3(Mathf.Abs(deltaX),size.y,size.z);

        return data;
    }
}
