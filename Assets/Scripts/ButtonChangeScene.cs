using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonChangeScene : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Change);
    }

    void Change()
    {
        SceneManager.LoadScene(sceneName);
    }
}
