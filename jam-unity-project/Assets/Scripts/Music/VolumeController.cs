using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public AudioMixer AudioMixer;

    private void Start()
    {
        WhenItsDone();
    }

    public void WhenItsDone()
    {
        AudioMixer.SetFloat("volume", -31f);
    }
}