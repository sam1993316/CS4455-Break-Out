using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepSound : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip[] clips;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.Log("Audio Source cannot be found.");
        }
    }

    void Step()
    {
        //AudioClip clip = GetRandomClip();
        AudioClip clip = clips[0];
        audioSource.PlayOneShot(clip);
    }

    //AudioClip GetRandomClip()
    //{
    //    return clips[UnityEngine.Random.Range(0, clips.Length)];
    //}
}
