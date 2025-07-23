using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager2 : MonoBehaviour
{
    // Start is called before the first frame update
    private static PlayerManager2 instance;

    public static PlayerManager2 Instance
    {
        get { return instance; }
        set { instance = value; }
    }


    public float fireRate = 1.0f;     // 발사 간격
    public float bulletSpeed = 10f;   // 총알 속도
    public float moveSpeed = 5f;
    public float jumpForce = 3f;
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;

    public bool isHomingBullet = false;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 존재하면 중복 생성 방지
        }
    }
    
}
