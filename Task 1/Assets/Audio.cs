using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    //один звук - один префаб. Настраивать в префабе каждый
    AudioClip clip;
    AudioSource source;

    private void Update()
    {
       // AudioSource.PlayClipAtPoint - создает клип в месте касания коллайдера например и проигрывает а потом удаляется
    }
}
