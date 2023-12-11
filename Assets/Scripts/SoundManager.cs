using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioFile;
    public AudioClip soundClip1;
    public AudioClip soundClip2;

    public GameObject inhale1;
    public GameObject inhale2;
    public GameObject inhale3;
    
    public GameObject exhale1;
    public GameObject exhale2;
    public GameObject exhale3;
    


    // Start is called before the first frame update
    void Start()
    {
        audioFile = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inhale1.activeSelf)
        {
            audioFile.PlayOneShot(soundClip1, 1f);
        }

        if(inhale2.activeSelf)
        {
            audioFile.PlayOneShot(soundClip1, 1f);
        }

        if(inhale3.activeSelf)
        {
            audioFile.PlayOneShot(soundClip1, 1f);
        }

        if(exhale1.activeSelf)
        {
            audioFile.PlayOneShot(soundClip1, 1f);
        }

        if(exhale2.activeSelf)
        {
            audioFile.PlayOneShot(soundClip1, 1f);
        }

        if(exhale3.activeSelf)
        {
            audioFile.PlayOneShot(soundClip1, 1f);
        }
    }
}
