using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameOver;
    public static bool gameStarted;
    public static int gameScore;

    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject getReadyPanel;
    [SerializeField] private GameObject score;
    [SerializeField] private Score scoreScript;

    private void Awake() 
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        gameOver = false;
        gameStarted = false;
    }

    private void Start()
    {
        gameOverMenu.SetActive(false);
    }

    public void GameOver()
    {
        gameScore = scoreScript.GetScore();

        gameOver = true;

        gameOverMenu.SetActive(true);

        score.SetActive(false);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        gameOverMenu.SetActive(false);
    }

    public void GameHasStarted()
    {
        gameStarted = true;
        getReadyPanel.SetActive(false);
    }
}
