using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject[] prefabs;
    private GameObject instance;

    public Material mat;

    private void OnJump()
    {
        foreach (var pref in prefabs)
        {
            if (pref == null)
            {
                Debug.Log("Missing prefab");
                return;
            }
        }

        if (instance != null)
            Destroy(instance);

        var x = Random.Range(-10.0f, 10.0f);
        var y = Random.Range(-10.0f, 10.0f);
        var z = Random.Range(-10.0f, 10.0f);

        var rot = Quaternion.identity;
        var pos = new Vector3(x, y, z);
        var index = Random.Range(0, prefabs.Length);

        prefabs[index].GetComponent<MeshRenderer>().material = mat;
        instance = Instantiate(prefabs[index], pos, rot);
    }
}
