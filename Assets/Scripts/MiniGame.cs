using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    private bool isMiniGameActive = false;

    public void StartMiniGame()
    {
        isMiniGameActive = true;
        // 미니게임 시작 로직 추가
    }

    public void EndMiniGame()
    {
        isMiniGameActive = false;
        // 미니게임 종료 로직 추가
    }

    private void Update()
    {
        if (isMiniGameActive)
        {
            // 미니게임 진행 중일 때의 로직
        }
    }
}

