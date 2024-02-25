using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider hit)
    {
        if(hit.tag == "KillZoneTag")
        {
            Destroy(gameObject);
        }
    }
}
