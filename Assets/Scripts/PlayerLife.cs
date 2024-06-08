using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int maxLife;
    private SpriteRenderer spriteRenderer;
    private bool damageFeedback;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        UIController.Instance.SetLifeText(life);
    }

    private void ChangeLife(int value)
    {
        if (damageFeedback && value < 0)
        {
            return;
        }
        life += value;
        if (life > maxLife)
        {
            life = maxLife;
        }
        if (life < 0)
        {
            life = 0;
        }

        if (value < 0)
        {
            if (!damageFeedback)
            {
                StartCoroutine(DamageAnimation());
            }
        }
        UIController.Instance.SetLifeText(life);
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator DamageAnimation()
    {
        damageFeedback = true;
        int count = 0;
        while (count < 5)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.1f);
            count++;
        }
        damageFeedback = false;
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
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            ChangeLife(-collision.gameObject.GetComponent<Damage>().GetDamage());
            Destroy(collision.gameObject);
        }
    }

}
