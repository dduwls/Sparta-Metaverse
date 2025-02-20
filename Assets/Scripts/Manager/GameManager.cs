using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    private UIManager uIManager;
    public UIManager UIManager => uIManager;

    private int currentScore = 0;

    private void Awake()
    {
        instance = this;
        uIManager = FindAnyObjectByType<UIManager>();
    }

    private void Start()
    {
        uIManager.UpdateScore(0);
    }

    public void GameOver()
    {
        uIManager.SetRestart();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uIManager.UpdateScore(currentScore);
    }
}
