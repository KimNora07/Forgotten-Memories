using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour, IState<Enemy>
{
    private Enemy m_Enemy;

    public void OperateEnter(Enemy sender)
    {
        m_Enemy = sender;
        m_Enemy.moveSpeed = 1.5f;
    }
    public void OperateUpdate(Enemy sender)
    {
        if (m_Enemy)
        {
            if (m_Enemy.moveSpeed > 0)
            {
                m_Enemy.transform.Translate(Vector2.right * (float)m_Enemy.currentDirection * (m_Enemy.moveSpeed * Time.deltaTime));
            }
        }
    }
    public void OperateExit(Enemy sender)
    {
        if (m_Enemy)
        {
            m_Enemy.moveSpeed = 0;
        }
    }
}
