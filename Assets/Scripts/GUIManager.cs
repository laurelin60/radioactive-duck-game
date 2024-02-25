using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public Text score;
    public static string ScoreState = "score: 0";

    public void SetScore(int newScore)
    {
        Debug.Log(newScore);
        score.text = "score: " + newScore;
        ScoreState = score.text;
    }
}
