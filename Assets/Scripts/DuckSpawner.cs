using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    public GameObject Duck;

    public void SpawnDuck()
    {
        Instantiate(Duck, transform.position, transform.rotation);
    }
}
