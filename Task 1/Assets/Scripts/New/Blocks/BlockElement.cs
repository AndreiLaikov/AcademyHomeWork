using UnityEngine;

namespace StackApp.Blocks
{
    public class BlockElement : MonoBehaviour
    {
        [SerializeField] private MeshFilter blockMesh;
        public MeshFilter BlockMesh => blockMesh;

        [SerializeField] private BoxCollider blockCollider;
        public BoxCollider BlockCollider => blockCollider;

        [SerializeField] private Rigidbody rBody;//todo is it OK to add rigid body with isKinematic=true or better addComponent only to falling block?
        public Rigidbody RBody => rBody;

        [SerializeField] private Material blockMaterial;
        public Material BlockMaterial => blockMaterial;
    }
}