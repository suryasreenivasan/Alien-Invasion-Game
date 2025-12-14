using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        UpdateScore(0);
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateScore(int points)
    {
        score += points;
        PlayerPrefs.SetInt("score", score);
        scoreText.text = "Score: " + score;
    }
}
