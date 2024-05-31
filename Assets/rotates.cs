using UnityEngine;

public class RotateEarth : MonoBehaviour
{
    public Transform targetObject; // ȸ����ų ��� ������Ʈ�� Transform
    public float rotationSpeed = 10f; // ������Ʈ�� ȸ�� �ӵ� (degrees per second)
    public float stopAngle = 90f; // ȸ���� ���� ����
    private float currentRotation = 0f; // ���� ȸ���� ����
    private bool isReversing = false; // �ݴ� �������� ȸ�� ������ Ȯ���ϴ� �÷���
    private bool hasReversed = false; // ��ȸ���� �ߴ��� Ȯ���ϴ� �÷���
    private bool stop = false;
    public bool enabled = false;

    public void StartRotation()
    {
        enabled = true; // ��ũ��Ʈ Ȱ��ȭ'
        stop = false;
    }

    void StopRotation()
    {
        enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
    }

    void Update()
    {
        if (!enabled || targetObject == null)
            return; // ��ũ��Ʈ�� ��Ȱ��ȭ�Ǿ� �ְų� ����� �������� �ʾ����� �ƹ� �۾��� ���� ����

        // ���� ȸ�� �ӵ� ��� (������ �Ǵ� ������)
        float speed = isReversing ? -rotationSpeed : rotationSpeed;

        // ȸ���� ���� ���
        float rotationThisFrame = speed * Time.deltaTime;
        currentRotation += rotationThisFrame;

        // ���� ������ ���� ȸ���� ���߰ų� �ݴ� �������� ȸ�� ����
        if (!isReversing && currentRotation >= stopAngle && !hasReversed)
        {
            isReversing = true; // �ݴ� �������� ȸ�� ����
            hasReversed = true; // ��ȸ���� ������ ǥ��
        }
        else if (isReversing && currentRotation <= 0f)
        {
            isReversing = false; // ȸ�� ����
            currentRotation = 0f; // ��Ȯ�ϰ� 0���� ���߱�
            stop = true;
        }
        
        // ��� ������Ʈ�� ȸ����ŵ�ϴ�.
        if (!stop)
        {
            targetObject.Rotate(Vector3.up, rotationThisFrame);
        }
        if(stop)
        {
            isReversing = false;
            hasReversed = false;
            currentRotation = 0f;
            enabled = false;
        }
    }
    
}
