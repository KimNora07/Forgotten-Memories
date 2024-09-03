public class StateMachine<T>
{
    private T m_sender;

    public IState<T> CurState { get; set; }

    public StateMachine(T sender,  IState<T> newState)
    {
        m_sender = sender;
        SetState(newState);
    }

    public void SetState(IState<T> state)
    {
        if (m_sender == null) return;
        if (CurState == state) return;
        if (CurState != null) CurState.OperateExit(m_sender);

        CurState = state;

        if(CurState != null) CurState.OperateEnter(m_sender);
    }

    public void DOOperateUpdate()
    {
        if(m_sender == null) return;

        CurState.OperateUpdate(m_sender);
    }
}
