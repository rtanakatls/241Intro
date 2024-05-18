using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private EnemyLife enemyLife;

    [SerializeField] private MonoBehaviour[] bossPhase;

    [SerializeField] private int currentPhase;

    private void Awake()
    {
        enemyLife = GetComponent<EnemyLife>();
        ChangePhase(0);
    }


    void ChangePhase(int index)
    {
        if (currentPhase==index)
        {
            return;
        }

        for(int i=0;i<bossPhase.Length; i++)
        {
            bossPhase[i].enabled = false;
        }
        currentPhase = index;
        bossPhase[index].enabled = true;
    }

    private void Update()
    {
        ChangeSize();
        ControlPhase();
    }

    void ChangeSize()
    {
        transform.localScale = Vector3.one * (enemyLife.GetMaxLife() - enemyLife.GetLife() + 1);
    }

    void ControlPhase()
    {
        if (enemyLife.GetLife() > enemyLife.GetMaxLife() / 2)
        {
            ChangePhase(0);
        }
        else
        {
            ChangePhase(1);
        }
    }


}
