using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : MonoBehaviour, IState<PlayerContoller>
{
    private PlayerContoller m_Contoller;

    public void OperateEnter(PlayerContoller sender)
    {
        m_Contoller = sender;
        if(m_Contoller != null)
        {
            m_Contoller.moveSpeed = 0;
        }
    }
    public void OperateUpdate(PlayerContoller sender)
    {

    }
    public void OperateExit(PlayerContoller sender)
    {

    }
}
