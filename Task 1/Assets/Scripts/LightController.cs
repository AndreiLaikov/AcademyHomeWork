using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light _light;
    public float min_intensity;
    public float max_intensity;
    public AudioSource audioSource;

    private float timer = 0.2f;

    public void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            _light.intensity = Random.Range(min_intensity, max_intensity);
            _light.enabled = !_light.enabled;
            
            timer = Random.Range(0.01f, 0.7f);
            if (_light.enabled)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }

        }
    }

}
