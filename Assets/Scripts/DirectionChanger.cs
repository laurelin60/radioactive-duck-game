using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionChanger : MonoBehaviour
{
    public enum DirChanger {Horizontal, Vertical};
    public DirChanger changer;

    void Start()
    {
        TurnOn();
        GameManager.OnDuckShot += TurnOff;
        GameManager.OnDuckMiss += TurnOff;
        GameManager.OnSpawnDucks += TurnOn;
    }

    void OnCollisionEnter(Collision hit)
    {
        if(hit.transform.tag == "Duck")
        {
            DuckMovement duck = hit.gameObject.GetComponent<DuckMovement>();

            if(changer == DirChanger.Horizontal)
            {
                duck.DirectionChanger(new Vector3(-1, 1, 0));
            }
            else if(changer == DirChanger.Vertical)
            {
                duck.DirectionChanger(new Vector3(1, -1, 0));
            }
        }
    } 
    
    public void TurnOff()
    {
        gameObject.SetActive(false);
    }

    public void TurnOn(){
        gameObject.SetActive(true);
    }
}
