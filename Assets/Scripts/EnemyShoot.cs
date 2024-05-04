using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private Transform player;
    [SerializeField] private GameObject bulletPrefab;
    private float shootTimer;
    [SerializeField] private float shootDelay;
    [SerializeField] private float shootingRange;
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        float distance = Vector2.Distance(player.position, transform.position);

        if (distance > shootingRange)
        {
            Vector2 direction = player.position - transform.position;
            direction = direction.normalized;
            rb2d.velocity = direction * speed;
        }
        else
        {
            rb2d.velocity=Vector2.zero;
        }

    }

    void Shoot()
    {
        float distance = Vector2.Distance(player.position, transform.position);

        if (distance <= shootingRange)
        {
            shootTimer += Time.deltaTime;


            if (shootTimer >= shootDelay)
            {
                GameObject obj = Instantiate(bulletPrefab);
                obj.transform.position = transform.position;
                Vector2 direction = player.position - obj.transform.position;
                direction = direction.normalized;
                obj.GetComponent<Bullet>().SetDirection(direction);
                shootTimer = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
