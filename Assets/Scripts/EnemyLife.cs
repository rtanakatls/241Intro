using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int maxLife;

    public float GetLife()
    {
        return life;
    }

    public float GetMaxLife()
    {
        return maxLife;
    }

    public void ChangeLife(int value)
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
