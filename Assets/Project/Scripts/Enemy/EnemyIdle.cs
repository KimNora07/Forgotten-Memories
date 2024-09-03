using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : MonoBehaviour, IState<Enemy>
{
    private Enemy m_Enemy;

    public void OperateEnter(Enemy sender)
    {
        m_Enemy = sender;
        if (m_Enemy != null)
        {
            m_Enemy.moveSpeed = 0;
        }
    }   
    public void OperateUpdate(Enemy sender)
    {

    }
    public void OperateExit(Enemy sender)
    {

    }   
}
