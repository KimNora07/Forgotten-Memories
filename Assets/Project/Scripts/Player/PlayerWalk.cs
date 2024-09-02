using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour, IState<PlayerContoller>
{
    private PlayerContoller m_Contoller;

    public void OperateEnter(PlayerContoller sender)
    {
        m_Contoller = sender;
        m_Contoller.moveSpeed = 2;
    }
    public void OperateUpdate(PlayerContoller sender)
    {
        if (m_Contoller)
        {
            if (m_Contoller.moveSpeed > 0)
            {
                m_Contoller.transform.Translate(Vector2.right * (float)m_Contoller.currentDirection * (m_Contoller.moveSpeed * Time.deltaTime));
            }
        }
    }
    public void OperateExit(PlayerContoller sender)
    {
        if (m_Contoller)
        {
            m_Contoller.moveSpeed = 0;
        }
    }
}
