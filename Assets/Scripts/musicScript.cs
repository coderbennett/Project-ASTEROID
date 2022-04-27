using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicScript : MonoBehaviour
{
    public AudioSource music;
    private bool musicOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(volumeScript.volume == 0)
        {
            if (!musicOn)
            {
              music.Play();
              musicOn = true;
            }
        } else if (volumeScript.volume == 1 || volumeScript.volume == 2)
        {
            music.Pause();
            musicOn = false;
        }
    }
}
