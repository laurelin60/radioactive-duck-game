using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    public float speed;
    public Vector3 direction;

    void Start()
    {
        RandomDirection();
    }

    void Update()
    {
        //move the duck by changing the position of the transform. Times directions with speed.
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void RandomDirection()
    {
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(.4f, 1f), 0);
    }

    public void DirectionChanger(Vector3 _dir)
    {
        direction = new Vector3(direction.x * _dir.x, direction.y * _dir.y, 0);
    }
}
