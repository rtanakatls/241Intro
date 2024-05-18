using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int maxLife;

    private void Start()
    {
        UIController.Instance.SetLifeText(life);
    }

    private void ChangeLife(int value)
    {
        life += value;
        if (life > maxLife)
        {
            life = maxLife;
        }
        if (life < 0)
        {
            life = 0;
        }
        UIController.Instance.SetLifeText(life);
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard") || collision.gameObject.CompareTag("Enemy"))
        {
            ChangeLife(-collision.gameObject.GetComponent<Damage>().GetDamage());
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
