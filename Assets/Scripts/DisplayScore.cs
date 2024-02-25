using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Text score;
    void Start()
    {
        score.text = GUIManager.ScoreState;     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
