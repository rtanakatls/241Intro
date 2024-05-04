using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    [SerializeField] private int life;
    [SerializeField] private int maxLife;
    [SerializeField] private GameObject bulletPrefab;
    private Vector2 direction;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        direction = Vector2.up;
    }

    void Update()
    {
        Move();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.transform.position = transform.position;
            obj.GetComponent<Bullet>().SetDirection(direction);
        }

    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            direction= new Vector2(horizontal, vertical).normalized;
        }

        rb2d.velocity = new Vector2(horizontal, vertical).normalized * speed;


    }

    private void ChangeLife(int value)
    {
        life += value;
        if (life > maxLife)
        {
            life = maxLife;
        }
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ChangeLife(-1);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Cure"))
        {
            ChangeLife(1);
            Destroy(collision.gameObject);
        }
    }
}
