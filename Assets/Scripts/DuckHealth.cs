using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckHealth : MonoBehaviour
{
    Animator anim;

    bool isInvincible;

    void Start()
    {
        anim = GetComponent<Animator>();
        GameManager.OnDuckMiss += MakeInvincible;
        GameManager.OnDuckShot += MakeInvincible;
        GameManager.ShootDuck += KillDuck;
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.tag == "KillZoneTag")
        {
            Destroy(gameObject);
            GameManager.OnDuckDeath();
        }

        if(hit.tag == "FlyZone")
        {
            Debug.Log("HIT FLY AWAY ZONE");
            Destroy(gameObject);
            GameManager.OnDuckFlyAway();
        }
    }

    public void KillDuck()
    {
        if(isInvincible == false)
        {
            Debug.Log("SHOT DUCK");
            anim.Play("DuckDead");
            GameManager.OnDuckShot();
        }
    }

    public void MakeInvincible()
    {
        isInvincible = true;
    }
}
