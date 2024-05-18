using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;

    private Camera cam;
    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDirection = mousePosition - transform.position;
        mouseDirection = mouseDirection.normalized;


        transform.up = mouseDirection;
        rb2d.velocity = new Vector2(horizontal, vertical).normalized * speed;


    }
}
