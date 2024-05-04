using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    [SerializeField] private int life;

    private float timer;
    private float yTimer;
    private bool goingUp;

    [SerializeField] private float changeDirectionTime;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            timer = 0;
            direction.x *=  -1;
        }

        if (goingUp)
        {
            yTimer += Time.deltaTime;
        }
        else
        {
            yTimer -= Time.deltaTime;
        }

        if (yTimer >= 1)
        {
            goingUp = false;
        }
        else if (yTimer <= -1)
        {
            goingUp = true;
        }

        direction.y = yTimer;

        rb2d.velocity = direction.normalized * speed;

    }

    private void ChangeLife(int value)
    {
        life += value;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            ChangeLife(-1);
            Destroy(collision.gameObject);
        }
    }
}
