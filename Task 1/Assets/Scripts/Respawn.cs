
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject Ellen;
    private GameObject instance;

    public Transform spawnPos;

    public void RespawnEllen()
    {
        if(instance != null)
        {
            Destroy(instance);
        }
        instance = Instantiate(Ellen, spawnPos.position, spawnPos.rotation);
    }

    private void Start()
    {
        RespawnEllen();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RespawnEllen();
        }
    }
}
