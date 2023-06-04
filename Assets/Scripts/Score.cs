using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;
    private int score;

    private void Awake() 
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();   
    }

    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
    }

}
