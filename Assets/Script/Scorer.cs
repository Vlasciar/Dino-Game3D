using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Scorer : MonoBehaviour
{
    public TextMesh Score_Sesion;
    public TextMesh High_Score;
    private int Score;
    void Start()
    {
        Set_HighScore();
    }
    private float Time_Elapsed;
    void Update()
    {
        if (!Player.Game_Over)
            Time_Elapsed += Time.deltaTime;

        Score = Mathf.RoundToInt(Time_Elapsed * 10);
        if (Score < 10)
            Score_Sesion.text = String.Concat("0000"  , Score.ToString());
        else if (Score < 100)
            Score_Sesion.text = String.Concat("000", Score.ToString());
        else if (Score < 1000)
            Score_Sesion.text = String.Concat("00", Score.ToString());
        else if (Score < 10000)
            Score_Sesion.text = String.Concat("0", Score.ToString());
        else 
            Score_Sesion.text = Score.ToString();

        if (Player.Game_Over )
        {
            if (Score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", Score);
            }
            Set_HighScore();
            if(Input.GetKey(KeyCode.Space))
            Game_Reset();
        }
    }
    void Game_Reset()
    {                
        GameObject[] obstacles;
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            GameObject.Destroy(obstacle);
        }
        Player.Game_Over = false;
        Time_Elapsed = 0;        
    }
    void Set_HighScore()
    {
        int HighScore = PlayerPrefs.GetInt("HighScore");
        if (HighScore < 10)
            High_Score.text = String.Concat("HI 0000", HighScore.ToString());
        else if (HighScore < 100)
            High_Score.text = String.Concat("HI 000", HighScore.ToString());
        else if (HighScore < 1000)
            High_Score.text = String.Concat("HI 00", HighScore.ToString());
        else if (HighScore < 10000)
            High_Score.text = String.Concat("HI 0", HighScore.ToString());
        else
            High_Score.text = String.Concat("HI ", HighScore.ToString());
    }
}
