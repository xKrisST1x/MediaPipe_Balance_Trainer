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
    public GameObject inhaleFull;
    
    public GameObject exhale1;
    public GameObject exhale2;
    public GameObject exhale3;
    public GameObject exhaleFull;
    
    bool inhale1Played = true;


    // Start is called before the first frame update
    void Start()
    {
        audioFile = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inhale1.activeSelf && inhale1Played == true)
        {
            audioFile.PlayOneShot(soundClip1, 1f);
            StartCoroutine(SoundTimer());
        }

        if(inhale2.activeSelf && inhale1Played == true)
        {
            audioFile.PlayOneShot(soundClip1, 1f);
            StartCoroutine(SoundTimer());
        }

        if(inhale3.activeSelf && inhale1Played == true)
        {
            audioFile.PlayOneShot(soundClip1, 1f);
            StartCoroutine(SoundTimer());
        }

        if(inhaleFull.activeSelf && inhale1Played == true)
        {
            audioFile.PlayOneShot(soundClip2, 1f);
            StartCoroutine(SoundTimer());
        }

        if(exhale1.activeSelf && inhale1Played == true)
        {
            audioFile.PlayOneShot(soundClip1, 1f);
            StartCoroutine(SoundTimer());
        }

        if(exhale2.activeSelf && inhale1Played == true)
        {
            audioFile.PlayOneShot(soundClip1, 1f);
            StartCoroutine(SoundTimer());
        }

        if(exhale3.activeSelf && inhale1Played == true)
        {
            audioFile.PlayOneShot(soundClip1, 1f);
            StartCoroutine(SoundTimer());
        }

        if(exhaleFull.activeSelf && inhale1Played == true)
        {
            audioFile.PlayOneShot(soundClip2, 1f);
            StartCoroutine(SoundTimer());
        }
    }

    private IEnumerator SoundTimer()
    {
        inhale1Played = false;
        yield return new WaitForSeconds(1f);
        inhale1Played = true;

    }
}
