using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private Camera cam;
    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void Update()
    {
        Shoot();
    }
    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouseDirection = mousePosition - transform.position;
            mouseDirection = mouseDirection.normalized;

            GameObject obj = Instantiate(bulletPrefab);
            obj.transform.position = transform.position;
            obj.GetComponent<Bullet>().SetDirection(mouseDirection);
        }

    }
}
