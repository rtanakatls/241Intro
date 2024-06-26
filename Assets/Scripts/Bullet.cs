using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    void Update()
    {
        rb2d.velocity = direction.normalized * speed;

    }
}
