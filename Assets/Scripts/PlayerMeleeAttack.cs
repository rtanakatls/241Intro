using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask attackLayerMask;
    [SerializeField] private int damage;
    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, attackLayerMask);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.GetComponent<EnemyLife>() != null)
                {
                    colliders[i].gameObject.GetComponent<EnemyLife>().ChangeLife(-damage);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if(attackPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        }
    }
}
