
public interface IState<T>
{
    void OperateEnter(T sender);    // 해당 State 들어왔을때 1회 실행
    void OperateUpdate(T sender);   // 해당 State 업데이트 할때마다 실행
    void OperateExit(T sender);     // 해당 State 에서 다른 State 호출로 인해서 현재 State 종료할때 1회 실행
}
