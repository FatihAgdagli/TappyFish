using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameOver;

    [SerializeField] private GameObject gameOverMenu;
    private void Awake() 
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        gameOver = false;
    }

    private void Start()
    {
        gameOverMenu.SetActive(false);
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverMenu.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        gameOverMenu.SetActive(false);
    }
}
