using UnityEngine;

namespace StackApp.Blocks
{
    public class BlockElement : MonoBehaviour
    {
        [SerializeField] private MeshFilter blockMesh;
        public MeshFilter BlockMesh => blockMesh;

        [SerializeField] private BoxCollider blockCollider;
        public BoxCollider BlockCollider => blockCollider;

        [SerializeField] private Rigidbody rBody;//todo is it OK to add rigidbody with isKinematic=true or better addComponent only to falling block?
        public Rigidbody RBody => rBody;

        [SerializeField] private MeshRenderer blockRenderer;
        public MeshRenderer BlockRenderer => blockRenderer;
    }
}