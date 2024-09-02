
public interface IState<T>
{
    void OperateEnter(T sender);    // �ش� State �������� 1ȸ ����
    void OperateUpdate(T sender);   // �ش� State ������Ʈ �Ҷ����� ����
    void OperateExit(T sender);     // �ش� State ���� �ٸ� State ȣ��� ���ؼ� ���� State �����Ҷ� 1ȸ ����
}
