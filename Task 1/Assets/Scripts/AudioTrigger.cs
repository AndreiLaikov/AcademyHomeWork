using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !source.isPlaying)
        {
            source.Play();
        }
    }
}
