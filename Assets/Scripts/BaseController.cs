using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody; // 물리 이동을 위한 Rigidbody2D

    [SerializeField] private SpriteRenderer characterRenderer; // 캐릭터 스프라이트 렌더러 (좌우 반전용)
    [SerializeField] private Transform weaponPivot; // 무기의 회전 중심

    protected Vector2 movementDirection = Vector2.zero; // 이동 방향
    public Vector2 MovementDirection { get { return movementDirection; } } // 읽기 전용 이동 방향

    protected Vector2 lookDirection = Vector2.zero; // 바라보는 방향
    public Vector2 LookDirection { get { return lookDirection; } } // 읽기 전용 바라보는 방향

    private Vector2 knockback = Vector2.zero; // 넉백 방향과 힘
    private float knockbackDuration = 0.0f; // 넉백 지속 시간
    
    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();// Rigidbody2D 컴포넌트 가져오기
    }

    protected virtual void Start()
    {
        
    }
    
    protected virtual void Update()
    {
        HandleAction(); // 입력 처리 (이동 방향 & 바라보는 방향 업데이트)
        Rotate(lookDirection); // 바라보는 방향으로 회전
    }
    
    protected virtual void FixedUpdate()
    {
        Movment(movementDirection); // 이동 처리
        if(knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;// 넉백 지속 시간 감소
        }
    }
    
    protected virtual void HandleAction()
    {
        
    }

    private void Movment(Vector2 direction)
    {
        direction = direction * 2;// 속도 조절 (4배 증가)
        if(knockbackDuration > 0.0f)
        {
            direction *= 0.2f;// 넉백 중이면 이동 속도 감소 (20% 유지)
            direction += knockback;// 넉백 힘 추가
        }
        
        _rigidbody.velocity = direction;// Rigidbody2D에 속도 적용
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // 방향을 각도로 변환
        bool isLeft = Mathf.Abs(rotZ) > 90f; // 90도 이상이면 왼쪽을 바라봄
    
        characterRenderer.flipX = isLeft; // 스프라이트 반전 (왼쪽이면 true, 오른쪽이면 false)
    
        if (weaponPivot != null)
        {
            weaponPivot.rotation = Quaternion.Euler(0, 0, rotZ); // 무기 회전
        }
    }
    
    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;// 넉백 지속 시간 설정
        knockback = -(other.position - transform.position).normalized * power;// 반대 방향으로 힘 추가
    }    
}
