using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    [SerializeField] private float followRange;
    [SerializeField] private float stopRange;

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
    }

    void Move()
    {
        if (player == null)
        {
            return;
        }
        float distance = Vector2.Distance(player.position, transform.position);

        if (distance < followRange && distance > stopRange)
        {
            Vector2 direction = player.position - transform.position;
            direction = direction.normalized;
            rb2d.velocity = direction * speed;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stopRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followRange);
    }
}
