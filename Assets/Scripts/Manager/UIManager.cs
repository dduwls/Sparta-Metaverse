using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI countdownText;  // 카운트다운 숫자 표시할 UI 텍스트
    public GameObject gameplayUI;  // 게임 UI (점수 표시 등)
    public GameObject countdownUI; // 카운트다운 UI
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI restartText;
    private PlayerController playerController; // 플레이어 조작 스크립트

    public int Score { get; set; }

    private void Start()
    {
        // 플레이어 조작 비활성화
        playerController = FindObjectOfType<PlayerController>(); // PlayerController 찾기
        if (playerController != null) playerController.enabled = false;

        // 게임 일시정지
        Time.timeScale = 0f;

        if (scoreText == null) Debug.LogError("Score Text is NULL.");
        if (restartText == null) Debug.LogError("Restart Text is NULL.");

        restartText.gameObject.SetActive(false);
        StartCoroutine(StartCountdown()); // 카운트다운 시작
    }

    IEnumerator StartCountdown()
    {
        yield return new WaitForSecondsRealtime(2f);

        countdownUI.SetActive(true);  // 카운트다운 UI 활성화
        int countdown = 3;

        while (countdown > 0)
        {
            countdownText.text = countdown.ToString(); // "3", "2", "1" 표시
            yield return new WaitForSecondsRealtime(1f);
            countdown--;
        }

        countdownText.text = "START!";
        yield return new WaitForSecondsRealtime(0.5f); // "START!" 잠깐 표시

        countdownUI.SetActive(false); // 카운트다운 UI 숨김
        gameplayUI.SetActive(false);  // 게임 UI 비활성화

        // 게임 시작 (조작 가능하게 변경)
        if (playerController != null) playerController.enabled = true; // 플레이어 조작 활성화
        Time.timeScale = 1f; // 게임 재개
    }

    public void SetRestart()
    {
        // restartText.gameObject.SetActive(true);
        gameplayUI.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        Score = score;
        scoreText.text = score.ToString();
    }
}