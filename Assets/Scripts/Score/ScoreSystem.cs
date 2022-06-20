using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : Singleton<ScoreSystem>
{
    public int CurrentScore { get; private set; }

    public void AddScore(int scoreToAdd)
    {
        CurrentScore += scoreToAdd;
        FindObjectOfType<ScoreTextUpdater>()?.SetScore(CurrentScore);
    }
    void Start()
    {
        CurrentScore = 0;
    }
    
    public void ResetScore()
    {
        Destroy(gameObject);
    }

}
