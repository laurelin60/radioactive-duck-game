using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    public float speed;
    public Vector3 direction;

    private int bounce;
    public int bounceMax;


    void Start()
    {
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
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(.4f, 1f), 0);
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
}
