using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOld : MonoBehaviour
{
    private int count;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            count++;
            Debug.Log(count);
            timer = 0;
        }
    }
}
