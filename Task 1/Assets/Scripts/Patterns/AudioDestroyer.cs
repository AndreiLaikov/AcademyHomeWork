using UnityEngine;

public class AudioDestroyer : MonoBehaviour
{
    private AudioSource audioPlayer;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!audioPlayer.isPlaying)
            Destroy(gameObject);
    }
}
