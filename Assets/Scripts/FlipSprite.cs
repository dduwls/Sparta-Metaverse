using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Vector3 lastPosition;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector3 moveDirection = transform.position - lastPosition;
        if (moveDirection.x > 0) // 오른쪽으로 이동 중
            spriteRenderer.flipX = true;
        else if (moveDirection.x < 0) // 왼쪽으로 이동 중
            spriteRenderer.flipX = false;

        lastPosition = transform.position;
    }
}
