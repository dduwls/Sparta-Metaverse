using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;
    private Animator animator;
    private Vector2 defaultLookDirection = Vector2.left; // 기본 왼쪽 방향 (-1, 0)

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
        animator = GetComponent<Animator>();
        lookDirection = defaultLookDirection; // 시작할 때 기본 방향 설정
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");//가로 입력, 왼쪽:-1, 오른쪽:1
        float vertial = Input.GetAxisRaw("Vertical");//세로 입력, 아래쪽:-1, 위쪽:1
        movementDirection = new Vector2(horizontal, vertial).normalized;

        // 좌우 이동 방향에 따라 몸을 회전
        if (horizontal > 0) // 오른쪽으로 이동할 때
        {
            transform.localScale = new Vector3(-1, 1, 1); // 오른쪽 방향 (기본)
        }
        else if (horizontal < 0) // 왼쪽으로 이동할 때
        {
            transform.localScale = new Vector3(1, 1, 1); // 왼쪽 방향 (반전)
        }

        if(horizontal != 0 || vertial != 0) //이동중인지 체크
        {
            animator.SetBool("IsWalk", true);
        }
        else
        {
            animator.SetBool("IsWalk", false);
        }
    }
}
