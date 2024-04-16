using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateMusic(float value)
    {
        audioMixer.SetFloat("MusicVolume",value);
    }
    public void UpdateSound(float value)
    {
        audioMixer.SetFloat("SoundVolume", value);
    }
}
