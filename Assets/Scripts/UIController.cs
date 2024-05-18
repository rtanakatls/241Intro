using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private static UIController instance;

    public static UIController Instance { get { return instance; } }


    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
    }

    public void SetLifeText(int life)
    {
        lifeText.text = $"Life: {life}";
    }

    public void SetScoreText(int score)
    {
        scoreText.text = $"Score: {score}";
    }
}
