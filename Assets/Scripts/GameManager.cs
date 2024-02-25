using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        score = 0;
        currentDuck = -1;

        SetScore(score);

        OnDuckShot += IncrementScore;
        OnDuckShot += IncrementDucks;
        OnSpawnDucks += IncrementDucks;
        OnFinish += LoadEndScreen;
    }

   public void IncrementDucks() 
   {
        if (currentDuck < MaxDucks)
        {
            currentDuck++;
            Debug.Log($"DUCKS LEFT: {MaxDucks - currentDuck}");
        }
        else if(currentDuck >= MaxDucks)
        {
            OnFinish();
        }
   }

   public void SetScore(int newScore)
   {
        score = newScore;
   }

    private void IncrementScore()
    {
        score += scoreAmt;
        SetGUIScore(score);
    }

   private void SetGUIScore(int newScore)
   {
        Debug.Log($"NEW SCORE: {newScore}");
        manager.SetScore(newScore);
   }

    private void LoadEndScreen()
    {
        SceneManager.LoadScene("GameOver");
    }
}
