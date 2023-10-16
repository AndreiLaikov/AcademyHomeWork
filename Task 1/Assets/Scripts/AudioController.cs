using UnityEngine;

public class AudioController : MonoBehaviour
{
    //один звук - один префаб. Настраивать в префабе каждый
    public AudioSource FootstepAudio;
    public CharacterController PlayerMoveController;
 

    private void Update()
    {
        if (PlayerMoveController.velocity.sqrMagnitude > 0.5f)
        {
            if (!FootstepAudio.isPlaying)
            {
                FootstepAudio.Play();
            }
        }
        else
        {
            if (FootstepAudio.isPlaying)
            {
                FootstepAudio.Stop();
            }
        }
    }
}
