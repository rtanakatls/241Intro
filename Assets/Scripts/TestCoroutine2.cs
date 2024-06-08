using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoroutine2 : MonoBehaviour
{
    [SerializeField] private PlayerData data;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Execute());
    }

    private IEnumerator Execute()
    {
        yield return new CustomYield(data);
        Debug.Log("Execute");
    }
}
