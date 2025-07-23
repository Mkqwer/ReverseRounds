using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire2 : MonoBehaviour
{
    public GameObject bulletPrefab;   // 발사할 Bullet 프리팹
    public Transform playerTransform; // Player 오브젝트의 Transform을 할당

    float radius = 1.0f;       // 원 반경
    float nextFireTime = 0f;   // 다음 발사 시간

    void Update()
    {
        nextFireTime += Time.deltaTime;
        if (playerTransform == null)
            return;

        // 마우스 위치를 월드 좌표로 변환 (2D)
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = 0f;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        // 플레이어 기준 마우스 방향 벡터 (z축 고정)
        Vector2 dir = (Vector2)(mouseWorldPos - playerTransform.position);
        dir.Normalize();

        if (dir.sqrMagnitude > 0.001f)
        {
            // 각도 계산 (x, y 평면)
            float angle = Mathf.Atan2(dir.y, dir.x);

            // 원 위의 위치 계산
            Vector2 offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
            Vector2 targetPos = (Vector2)playerTransform.position + offset;
            transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z);

            // 마우스 클릭 시 총알 발사
            if (Input.GetMouseButtonDown(0) && bulletPrefab != null && nextFireTime >= PlayerManager2.Instance.fireRate)
            {
                GameObject bullet = Instantiate(
                    bulletPrefab,
                    transform.position,
                    Quaternion.identity
                );

                // 유도탄 설정 반영
                NormalBullet2 bulletScript = bullet.GetComponent<NormalBullet2>();
                if (bulletScript != null)
                {
                    bulletScript.isHoming = PlayerManager2.Instance.isHomingBullet;
                }

                // 발사 방향 적용
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = dir * PlayerManager2.Instance.bulletSpeed;
                }

                nextFireTime = 0f; // 발사 후 다음 발사 시간 초기화
            }
        }
    }
}
