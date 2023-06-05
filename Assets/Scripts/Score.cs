using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreBoardScore;
    [SerializeField] private Text scoreBoardHighcore;
    [SerializeField] private GameObject newHighScore;

    private Text scoreText;
    private int score;
    private int highScore;

    private void Start() 
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        scoreBoardScore.text = score.ToString();

        highScore = PlayerPrefs.GetInt(nameof(highScore), 0);
        scoreBoardHighcore.text = highScore.ToString();
    }

    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
        scoreBoardScore.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
            scoreBoardHighcore.text = highScore.ToString();

            PlayerPrefs.SetInt(nameof(highScore), highScore);

            newHighScore.SetActive(true);
        }
    }

    public int GetScore()
    {
        return score;
    }
}
