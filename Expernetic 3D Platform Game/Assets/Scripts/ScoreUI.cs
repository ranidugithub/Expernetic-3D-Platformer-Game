using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        if (scoreText == null)
        {
            scoreText = GetComponent<Text>();
        }
    }

    void Update()
    {
        scoreText.text = "Score: " + ScoreManager.sManager.playerScore.ToString();
    }
}

