using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectVolumeController : MonoBehaviour
{
    private AudioSource soundEffect;
    private float volume = 0.5f;

    void Start()
    {
        soundEffect = GetComponent<AudioSource>();
    }

    void Update()
    {
        soundEffect.volume = volume;
    }

    public void SetVolume(float vol)
    {
        volume = vol;
    }
}
