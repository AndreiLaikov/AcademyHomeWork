using UnityEngine;

public class AudioDestroyer : MonoBehaviour
{
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!audio.isPlaying)
            Destroy(gameObject);
    }
}
