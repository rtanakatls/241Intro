using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Vector3 offset;
    
    void Update()
    {
        if(targetTransform == null)
        {
            return;
        }
        transform.position = targetTransform.position+offset;
    }
}
