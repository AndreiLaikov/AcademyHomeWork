using UnityEngine;

namespace StackApp.Block
{
    public class BlockElement : MonoBehaviour
    {
        [SerializeField] private MeshFilter blockMesh;
        public MeshFilter BlockMesh => blockMesh;

        [SerializeField] private BoxCollider blockCollider;
        public BoxCollider BlockCollider => blockCollider;

        [SerializeField] private Material blockMaterial;
        public Material BlockMaterial => blockMaterial;
    }
}