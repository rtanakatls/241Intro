using System;
using UnityEngine;
[Serializable]
public class PlayerData 
{
    [SerializeField] private int value;

    public int GetValue()
    {
        return value;
    }
}
