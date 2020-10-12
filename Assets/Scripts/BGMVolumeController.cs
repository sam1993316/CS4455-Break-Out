using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMVolumeController : MonoBehaviour
{

    private AudioSource bgm;
    private float volume = 0.5f;

    void Start()
    {
        bgm = GetComponent<AudioSource>();
    }

    void Update()
    {
        bgm.volume = volume;
    }

    public void SetVolume(float vol)
    {
        volume = vol;
    }
}
