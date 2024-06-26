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
    [SerializeField] private LayerMask blockingLayerMask;
    private void Start()
    {
       
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        Shoot();
    }


    void Shoot()
    {
        if (player == null)
        {
            return;
        }

        float distance = Vector2.Distance(player.position, transform.position);

        

        if (distance <= shootingRange)
        {
            shootTimer += Time.deltaTime;


            if (shootTimer >= shootDelay)
            {
                Vector2 direction = player.position - transform.position;
                direction = direction.normalized;
                RaycastHit2D detect = Physics2D.Raycast(transform.position, direction, distance, blockingLayerMask);
                Debug.DrawRay(transform.position, direction * distance,Color.white);
                if (!detect)
                {

                    GameObject obj = Instantiate(bulletPrefab);
                    obj.transform.position = transform.position;
                    obj.GetComponent<Bullet>().SetDirection(direction);
                    shootTimer = 0;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
