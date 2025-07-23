using UnityEngine;

public class NormalBullet2 : MonoBehaviour
{
    public bool isHoming = false;
    private Transform target;

    void Start()
    {
        if (isHoming)
        {
            FindClosestTarget();
        }
    }

    void Update()
    {
        if (isHoming && target != null)
        {
            Vector2 dir = ((Vector2)target.position - (Vector2)transform.position).normalized;
            transform.position += (Vector3)(dir * Time.deltaTime * 5f);
        }
    }

    void FindClosestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDist = Mathf.Infinity;
        GameObject closest = null;

        foreach (var enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = enemy;
            }
        }

        if (closest != null)
        {
            target = closest.transform;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyTest enemy = collision.gameObject.GetComponent<EnemyTest>();
            if (enemy != null)
            {
                enemy.TakeDamage(10f); // 고정 데미지
            }

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("World"))
        {
            Destroy(gameObject);
        }
    }
}
