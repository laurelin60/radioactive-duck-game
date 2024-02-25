using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text score;
    void Start()
    {
        score.text = GUIManager.ScoreState;     
    }
}
