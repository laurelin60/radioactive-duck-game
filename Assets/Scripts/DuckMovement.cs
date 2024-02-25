using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    public float speed;
    public Vector3 direction;

    private int bounce;
    public int bounceMax;

    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();

        GameManager.OnDuckShot += StopMovement;
        GameManager.OnDuckMiss += FlyAway;
        RandomDirection();
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void RandomDirection()
    {
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(.2f, 1f), 0);
        ChangeAnimation();
    }

    public void DirectionChanger(Vector3 _dir)
    {
        direction = new Vector3(direction.x * _dir.x, direction.y * _dir.y, 0);
        bounce++;

        if(bounce >= bounceMax)
        {
            direction = new Vector3(0, 1, 0);
            GameManager.OnDuckMiss();
        }
        ChangeAnimation();
    }

    public void StopMovement()
    {
        direction = new Vector3(0, 0, 0);
    }

    public void StartFall()
    {
        direction = new Vector3(0, -1, 0);
    }

    public void FlyAway()
    {
        direction = new Vector3(0, 1, 0);
    }

    private void ChangeAnimation()
    {
        if (direction.x < .5f && direction.x > 0f)
        {
            anim.Play("DuckFlyUpRight");
        }
        else if (direction.x > -.5f && direction.x < 0f)
        {
            anim.Play("DuckFlyUpLeft");
        }
        else if (direction.x < 1f && direction.x > .5f)
        {
            anim.Play("DuckFlySideRight");
        }
        else if (direction.x > -1f && direction.x < -.5f)
        {
            anim.Play("DuckFlySideLeft");
        }
        else if (direction.x == 0 && direction.y == 1)
        {
            anim.Play("DuckFlyAway");
        }
    }
}
