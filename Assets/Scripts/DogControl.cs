using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogControl : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        GameManager.OnDuckDeath += PlayDuck;
        GameManager.OnDuckFlyAway += PlayLaugh;
    }

    public void SpawnDucks()
    {
        GameManager.OnSpawnDucks();
    }

    public void PlayLaugh()
    {
        Debug.Log("PLAYED LAUGH");
        anim.Play("DogLaughAnim");
    }

    public void PlayDuck()
    {
        anim.Play("DogDuckAnim");
    }
}
