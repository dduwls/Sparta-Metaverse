using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI BestScoreText;   // 최고 점수 UI (결과창)
    public TextMeshProUGUI NowScoreText;    // 현재 점수 UI (결과창)

    public int NowScore { get; set; } = 0; // 현재 점수
    public int BestScore { get; set; } = 0; // 최고 점수

    void Start()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            BestScore = PlayerPrefs.GetInt("BestScore", 0);
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", 0);
            PlayerPrefs.Save();
        }

        UpdateUI();
    }

    public void GameOver()
    {
        if (NowScore > BestScore)
        {
            BestScore = NowScore;
            PlayerPrefs.SetInt("BestScore", BestScore);
            PlayerPrefs.Save();
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (BestScoreText != null) BestScoreText.text = BestScore.ToString();
        if (NowScoreText != null) NowScoreText.text = NowScore.ToString();

        // 강제 업데이트 적용
        BestScoreText.ForceMeshUpdate();
        NowScoreText.ForceMeshUpdate();
    }

    public void ResetScore()
    {
        NowScore = 0; // 현재 점수만 초기화
        UpdateUI();
    }
}

