using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadingScreenController : MonoBehaviour
{
    private static LoadingScreenController instance;
    [SerializeField] private Image background;
    [SerializeField] private TextMeshProUGUI loadingText;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
    }

    public static LoadingScreenController GetInstance()
    {
        return instance;
    }

    public void ShowLoadingScreen(string sceneName)
    {
        StartCoroutine(ShowLoading(sceneName));
    }

    IEnumerator ShowLoading(string sceneName)
    {
        background.gameObject.SetActive(true);
        Color color = new Color(0,0,0,0);
        background.color = color;
        while (background.color.a < 1)
        {
            color= background.color;
            color.a += Time.deltaTime; 
            background.color = color;
            yield return null;
        }
        AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);

        float timer=0;
        loadingText.gameObject.SetActive(true);
        while (loadSceneAsync.progress < 1f)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
            }

            if (timer < 1f/3f)
            {
                loadingText.text = "Cargando.";
            }
            else if (timer < 2f / 3f)
            {
                loadingText.text = "Cargando..";
            }
            else
            {
                loadingText.text = "Cargando...";
            }
            yield return null;
        }
        loadingText.gameObject.SetActive(false);
        HideLoadingScreen();
    }


    public void HideLoadingScreen()
    {
        StartCoroutine(HideLoading());
    }
    IEnumerator HideLoading()
    {
        background.gameObject.SetActive(true);
        Color color = new Color(0, 0, 0, 1);
        background.color = color;
        while (background.color.a > 0)
        {
            color = background.color;
            color.a -= Time.deltaTime;
            background.color = color;
            yield return null;
        }
        background.gameObject.SetActive(false);
        loadingText.gameObject.SetActive(false);

    }

}
