using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomYield : CustomYieldInstruction
{
    private PlayerData data;
    public override bool keepWaiting
    {
        get
        {
            return data.GetValue()!=9;
        }
    }

    public CustomYield( PlayerData data)
    {
        this.data = data;
    }
}
