using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour, IState<PlayerContoller>
{
    private PlayerContoller m_Contoller;

    public void OperateEnter(PlayerContoller sender)
    {
        m_Contoller = sender;
        m_Contoller.moveSpeed = 5;
    }
    public void OperateUpdate(PlayerContoller sender)
    {
        if (m_Contoller)
        {
            if (m_Contoller.moveSpeed > 0)
            {
                m_Contoller.body.velocity = new Vector2((float)m_Contoller.currentDirection * m_Contoller.moveSpeed, m_Contoller.body.velocity.y);
            }
        }
    }
    public void OperateExit(PlayerContoller sender)
    {
        if (m_Contoller)
        {
            m_Contoller.moveSpeed = 0;
            m_Contoller.body.velocity = new Vector2(0, m_Contoller.body.velocity.y);
        }
    }
}
