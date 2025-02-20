using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.PixelArtTopDown_Basic;

public class Trigger : MonoBehaviour
{
    public GameObject miniGameUI; // 미니게임 UI를 연결할 변수
    public GameObject miniGame;   // 미니게임을 실행할 객체 (필요한 경우)
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 캐릭터가 트리거 안으로 들어오면
        {
            player.GetComponent<TopDownCharacterController>().canMove = false;
            ShowMiniGameUI(); // 미니게임 UI를 보여준다
        }
    }

    private void ShowMiniGameUI()
    {
        // 미니게임 UI 활성화
        miniGameUI.SetActive(true);
    }
    
}
