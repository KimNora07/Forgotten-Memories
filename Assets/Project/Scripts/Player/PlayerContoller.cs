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
    public Rigidbody2D body;

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
        body = GetComponent<Rigidbody2D>();

        IState<PlayerContoller> idle = gameObject.AddComponent<PlayerIdle>();
        IState<PlayerContoller> walk = gameObject.AddComponent<PlayerWalk>();
        IState<PlayerContoller> run = gameObject.AddComponent<PlayerRun>();

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

        // 마우스 왼쪽 버튼 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 위치를 월드 좌표로 변환
            Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero);

            // Ray가 어떤 2D 오브젝트에 충돌했는지 체크
            if (hit.collider != null)
            {
                if (PlayerManager.Instance.canOpen)
                {
                    // hit 오브젝트의 정보 가져오기
                    GameObject clickedObject = hit.collider.gameObject;
                    Debug.Log("Clicked on: " + clickedObject.tag);

                    // 여기에 클릭된 오브젝트에 대한 처리 코드 작성
                }
            }
        }


        stateMachine.DOOperateUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FrontDoor"))
        {
            PlayerManager.Instance.canOpen = true;
        }
        if (collision.CompareTag("LeftDoor"))
        {
            PlayerManager.Instance.canOpen = true;
        }
        if (collision.CompareTag("RightDoor"))
        {
            PlayerManager.Instance.canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("FrontDoor"))
        {
            PlayerManager.Instance.canOpen = false;
        }
        if (collision.CompareTag("LeftDoor"))
        {
            PlayerManager.Instance.canOpen = false;
        }
        if (collision.CompareTag("RightDoor"))
        {
            PlayerManager.Instance.canOpen = false;
        }
    }
}
