using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void DuckDel();
    public static DuckDel OnSpawnDucks;
    public static DuckDel OnDuckShot;
    public static DuckDel OnDuckDeath;
    public static DuckDel OnDuckFlyAway;
    public static DuckDel OnDuckMiss;
    public static DuckDel ShootDuck;
    public static DuckDel OnFinish;

    public GUIManager manager;

    public int MaxDucks;
    private int currentDuck;

    public int scoreAmt;
    private int score; 

//     void Start()
//     {
//         score = 0;
//         currentDuck = 0;

//         SetScore();

//     }

//    public void IncrementDucks() 
//    {
//         if (currentDuck < MaxDucks)
//         {
//             currentDuck++;
//         }
//         else if(currentDuck >= MaxDucks)
//         {
//             OnFinish();
//         }
//    }

//    public void SetScore(int _score)
//    {
//         score.text = _score.toString();
//    }

//     private void IncrementScore()
//     {
//         score += scoreAmt;
//     }

//    private void SetScore()
//    {
//         manager.SetScore(score);
//    }

}
