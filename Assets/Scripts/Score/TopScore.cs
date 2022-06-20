using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Top score")]
public class TopScore : ScriptableObject
{
    public int Score = 0;
    public void UpdateScore(int newScore)
    {
        if(newScore > Score)
        {
            Score = newScore;
        }
    }
}
