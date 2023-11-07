using UnityEngine;

namespace StackApp.Block
{
    public interface IBlock
    {
        Vector3 BlockSize { get; set; }
        Vector3 BlockPosition { get; set; }
        Color BlockColor { get; set; }

        MeshFilter BlockMesh { get; set; }
        BoxCollider BlockCollider { get; set; }
        Material BlockMaterial { get; set; }

        void BlockSpawn();
    }
}