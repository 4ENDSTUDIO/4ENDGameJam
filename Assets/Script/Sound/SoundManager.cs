using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip Die, Hurt;
    static AudioSource audioSrc;
    void Start()
    {
        Die = Resources.Load<AudioClip>("Die");
        Hurt = Resources.Load<AudioClip>("Hurt");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playSound(string clip)
    {
        switch(clip)
        {
            case "Hurt":
                audioSrc.PlayOneShot(Hurt);
                break;
            case "Die":
                audioSrc.PlayOneShot(Die);
                break;
        }
    }
}
