using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float Period;
    public Damager prefab;
    public float StartDelay;
    [SerializeField] private float time;

    public void Update()
    {
        time += Time.deltaTime;

        if(time >= Period + StartDelay)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            time -= (Period+StartDelay);
            StartDelay = 0;
        }
    }
}
