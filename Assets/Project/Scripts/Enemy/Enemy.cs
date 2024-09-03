using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Move,

    }
    public float moveSpeed;

    public enum Direction
    {
        Left = -1,
        Right = 1
    }
    public Direction currentDirection;

    private Dictionary<EnemyState, IState<Enemy>> dicState = new Dictionary<EnemyState, IState<Enemy>>();
    private StateMachine<Enemy> stateMachine;

    // ½Ã¾ß (Field of View / using Raycast)
    public float distance;
    public LayerMask targetLayer;

    private void Start()
    {
        IState<Enemy> idle = new EnemyIdle();
        IState<Enemy> move = new EnemyMove();

        dicState.Add(EnemyState.Idle, idle);
        dicState.Add(EnemyState.Move, move);

        stateMachine = new StateMachine<Enemy>(this, dicState[EnemyState.Idle]);

        StartCoroutine(RandomSee());
    }

    private void Update()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.right * (float)currentDirection, distance, targetLayer);

        if (raycastHit.collider != null)
        {
            stateMachine.SetState(dicState[EnemyState.Move]);
            Debug.Log("11");
        }
        else
        {
            stateMachine.SetState(dicState[EnemyState.Idle]);
            Debug.Log("22");
        }

        Debug.DrawLine(transform.position, transform.position + Vector3.right * (float)currentDirection * distance, Color.red);

        stateMachine.DOOperateUpdate();
    }

    private IEnumerator RandomSee()
    {
        int rand = Random.Range(1, 3);

        switch (rand)
        {
            case 1: currentDirection = Direction.Left; break;
            case 2: currentDirection = Direction.Right; break;
        }

        yield return new WaitForSeconds(3);

        StartCoroutine(RandomSee());
    }
}
