using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 2f); // 2초 후에 총알 오브젝트 삭제
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("World"))
        {
            
            // 총알 오브젝트도 삭제
            Destroy(gameObject);
        }
        
    }
}
