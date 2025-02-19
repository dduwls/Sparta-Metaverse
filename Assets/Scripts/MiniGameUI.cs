using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameUI : MonoBehaviour
{
    public Button startButton; // 미니게임 시작 버튼
    public Button closeButton; // 미니게임 시작 버튼

    public void StartMiniGame()
    {
        // 버튼 클릭 시 미니게임을 시작하는 로직
        // 예시: 미니게임 오브젝트 활성화
        // miniGame.SetActive(true);
        gameObject.SetActive(false); // 미니게임 UI 비활성화
        // Todo: 씬 이동
        Debug.Log("미니게임 시작 뾰로롱!");
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false); // 미니게임 UI 비활성화
    }

    private void Awake()
    {
        startButton.onClick.AddListener(StartMiniGame);
        closeButton.onClick.AddListener(ClosePopup);
    }
}

