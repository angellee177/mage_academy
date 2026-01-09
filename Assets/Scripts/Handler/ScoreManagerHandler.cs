using System;
using UnityEngine;

public class ScoreManagerHandler : MonoBehaviour
{
    int score = 0;
    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int scoreToAdd)
    {
        score += scoreToAdd;
        score = Mathf.Clamp(score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
