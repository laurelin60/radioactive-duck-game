using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    //public text called score
    public Text score;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int newScore)
    {
        Debug.Log(newScore);
        score.text = "score: " + newScore;
    }
}
