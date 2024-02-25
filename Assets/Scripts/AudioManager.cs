using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource SFX;
    public AudioClip background;
    public AudioClip soundClip;

    private void Awake(){
        DontDestroyOnLoad(gameObject);
    }

    public void HitDuck(){
        SFX.clip = soundClip;
        SFX.Play();
    }

    void Start()
    {
        GameManager.OnDuckShot += HitDuck;
        musicSource.clip = background;
        musicSource.Play();
    }
}
