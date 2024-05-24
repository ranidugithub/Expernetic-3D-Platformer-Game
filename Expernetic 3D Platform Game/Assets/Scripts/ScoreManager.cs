using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager sManager;
    public int playerScore = 0;
    void Start()
    {
        sManager = this;
    }

    public void IncreaseScore(int Increase)
    {
        playerScore += Increase;
    }
}
