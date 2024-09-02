using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,
        Walk,
        Run
    }
    public float moveSpeed;

    public enum Direction
    {
        Left = -1,
        Right = 1
    }
    public Direction currentDirection;

    private Dictionary<PlayerState, IState<PlayerContoller>> dicState = new Dictionary<PlayerState, IState<PlayerContoller>>();
    private StateMachine<PlayerContoller> stateMachine;

    private void Start()
    {
        IState<PlayerContoller> idle = new PlayerIdle();
        IState<PlayerContoller> walk = new PlayerWalk();
        IState<PlayerContoller> run = new PlayerRun();

        dicState.Add(PlayerState.Idle, idle);
        dicState.Add(PlayerState.Walk, walk);
        dicState.Add(PlayerState.Run, run);

        stateMachine = new StateMachine<PlayerContoller>(this, dicState[PlayerState.Idle]);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            currentDirection = Direction.Left;
            stateMachine.SetState(dicState[PlayerState.Walk]);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                currentDirection = Direction.Left;
                stateMachine.SetState(dicState[PlayerState.Run]);
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                currentDirection = Direction.Left;
                stateMachine.SetState(dicState[PlayerState.Run]);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                currentDirection = Direction.Left;
                stateMachine.SetState(dicState[PlayerState.Walk]);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            currentDirection = Direction.Left;
            stateMachine.SetState(dicState[PlayerState.Walk]);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                currentDirection = Direction.Left;
                stateMachine.SetState(dicState[PlayerState.Run]);
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                currentDirection = Direction.Left;
                stateMachine.SetState(dicState[PlayerState.Run]);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                currentDirection = Direction.Left;
                stateMachine.SetState(dicState[PlayerState.Walk]);
            }
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            stateMachine.SetState(dicState[PlayerState.Idle]);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            currentDirection = Direction.Right;
            stateMachine.SetState(dicState[PlayerState.Walk]);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                currentDirection = Direction.Right;
                stateMachine.SetState(dicState[PlayerState.Run]);
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                currentDirection = Direction.Right;
                stateMachine.SetState(dicState[PlayerState.Run]);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                currentDirection = Direction.Right;
                stateMachine.SetState(dicState[PlayerState.Run]);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currentDirection = Direction.Right;
            stateMachine.SetState(dicState[PlayerState.Walk]);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                currentDirection = Direction.Right;
                stateMachine.SetState(dicState[PlayerState.Run]);
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                currentDirection = Direction.Right;
                stateMachine.SetState(dicState[PlayerState.Run]);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                currentDirection = Direction.Right;
                stateMachine.SetState(dicState[PlayerState.Run]);
            }
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            stateMachine.SetState(dicState[PlayerState.Idle]);
        }

        stateMachine.DOOperateUpdate();
    }

}
