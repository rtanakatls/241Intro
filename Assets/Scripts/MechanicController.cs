using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicController : MonoBehaviour
{
    private float timer;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject target;
    private Vector3 doorOriginalPosition;

    private bool opening;

    private void Awake()
    {
        doorOriginalPosition=door.transform.position;
    }

    public void OnButton()
    {
        opening = true;
    }

    public void OffButton()
    {
        opening = false;
    }

    private void Update()
    {
        if (opening)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        timer=Mathf.Clamp(timer, 0f, 1f);

        door.transform.position = Vector2.Lerp(doorOriginalPosition, target.transform.position, timer);
        
    }

}
