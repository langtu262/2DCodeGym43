using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{   
    //public AudioClip _backGround;
    public AudioClip[] backGrounds;
    public AudioClip click;
    public AudioClip fireAudio;
    public AudioClip explusion;
    public AudioSource backgroundMusic;
    public AudioSource soundFx;
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get { return _instance; }

        set
        {
            _instance = value;
        }
    }
    private void Start()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        BackGroundMusic(); 
    }
    public void PlayBackgroundMusic(AudioClip clip)
    {
        backgroundMusic.clip = clip;
        backgroundMusic.Play();
    }
    public void PlaySoundEffectMusic(AudioClip clip)
    {
        soundFx.PlayOneShot(clip);
    }
    
    public void BackGroundMusic()
    {
        PlayBackgroundMusic(backGrounds[Random.Range(0,backGrounds.Length)]);
    } 
    /*public void BackGroundMusic()
    {
        PlayBackgroundMusic(_backGround);
    }*/
   /* public void SoundEffectMusic()
    {
        PlaySoundEffectMusic(click);
    }*/

}
