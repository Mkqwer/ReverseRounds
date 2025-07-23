using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // New Input System을 위한 네임스페이스

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [Header("설정")]
    

    private Rigidbody2D rb;
    private PlayerInputActions controls;
    private Vector2 moveInput;            // 이동 입력
    private bool isJumpPressed;
    private bool isDashPressed;
    private bool isDashing;
    private float dashTime;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // 입력 시스템 인스턴스 생성
        controls = new PlayerInputActions();

        // Move 액션 값 변경 시 이벤트 등록
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += _ => moveInput = Vector2.zero;


        /*
        controls.Player.Debug.performed += _ =>
        {
            AddCard(CardList.jumpCard);
            Debug.Log(CardList.jumpCard.Name);
            UseCard(0);

        };
        */

        // Jump와 Dash는 performed 이벤트로 트리거만 감지
        controls.Player.Jump.performed += _ =>
        {
            isJumpPressed = true;
        };

        controls.Player.Dash.performed += _ =>
        {
            isDashPressed = true;
        };

    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    


    private void FixedUpdate()
    {





        if (isDashing)
        {
            rb.velocity = new Vector2(moveInput.x * PlayerManager.Instance.dashSpeed, rb.velocity.y);
            dashTime -= Time.fixedDeltaTime;
            if (dashTime <= 0)
            {
                isDashing = false;
            }
            return;
        }

        // 일반 이동 처리
        rb.velocity = new Vector2(moveInput.x * PlayerManager.Instance.moveSpeed, rb.velocity.y);

        // 점프 처리

        if (isJumpPressed && IsGrounded())
        {
            Debug.Log("점프!");
            rb.velocity = new Vector2(rb.velocity.x, PlayerManager.Instance.jumpForce);
        }
        
        
        // 대시 처리
        if (isDashPressed)
        {
            isDashing = true;
            dashTime = PlayerManager.Instance.dashDuration;
        }

        // 입력 초기화
        isJumpPressed = false;
        isDashPressed = false;

    }






    // 바닥 감지용 간단한 Raycast
    private bool IsGrounded()
    {
        Vector2 origin = (Vector2)transform.position + new Vector2(0, -0.5f);
        float rayLength = 0.6f;

        // 바닥 레이어로 설정된 레이어만 감지
        int groundMask = LayerMask.GetMask("Ground");

        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, rayLength, groundMask);

        // 디버그용 선 표시
        Debug.DrawRay(origin, Vector2.down * rayLength, Color.red);

        if (hit.collider != null)
        {
            Debug.Log("Grounded: YES");
            return true;
        }

        Debug.Log("Grounded: NO");
        return false;
    }


}