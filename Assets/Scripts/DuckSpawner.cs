using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    public GameObject Duck;

    void Start()
    {
        GameManager.OnSpawnDucks += SpawnDuck;
    }

    public void SpawnDuck()
    {
        Debug.Log("DUCK SPAWNED");
        Instantiate(Duck, transform.position, transform.rotation);
    }
}
