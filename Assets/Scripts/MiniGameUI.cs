using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cainos.PixelArtTopDown_Basic;

public class MiniGameUI : MonoBehaviour
{
    public Button startButton; // 미니게임 시작 버튼
    public Button closeButton; // 미니게임 시작 버튼
    public string sceneName;
    public GameObject player;

    public void StartMiniGame()
    {
        gameObject.SetActive(false); // 미니게임 UI 비활성화
        if (player != null) player.GetComponent<TopDownCharacterController>().canMove = true;

        Debug.Log("미니게임 시작 뾰로롱!");
        SceneManager.LoadScene(sceneName);
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false); // 미니게임 UI 비활성화
        player.GetComponent<TopDownCharacterController>().canMove = true;
    }

    private void Awake()
    {
        if (startButton != null) startButton.onClick.AddListener(StartMiniGame);
        if (closeButton != null) closeButton.onClick.AddListener(ClosePopup);
    }
}

