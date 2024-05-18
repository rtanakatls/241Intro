using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    private int score;


    private void ChangeScore(int value)
    {
        score += value;

        if (score >= 10)
        {
            SceneManager.LoadScene("Level1Scene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Score"))
        {
            ChangeScore(4);
            Destroy(collision.gameObject);
        }
    }
}
