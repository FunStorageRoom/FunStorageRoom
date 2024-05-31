using UnityEngine;

public class RotateEarth : MonoBehaviour
{
    public Transform targetObject; // 회전시킬 대상 오브젝트의 Transform
    public float rotationSpeed = 10f; // 오브젝트의 회전 속도 (degrees per second)
    public float stopAngle = 90f; // 회전을 멈출 각도
    private float currentRotation = 0f; // 현재 회전된 각도
    private bool isReversing = false; // 반대 방향으로 회전 중인지 확인하는 플래그
    private bool hasReversed = false; // 역회전을 했는지 확인하는 플래그
    private bool stop = false;
    public bool enabled = false;

    public void StartRotation()
    {
        enabled = true; // 스크립트 활성화'
        stop = false;
    }

    void StopRotation()
    {
        enabled = false; // 스크립트 비활성화
    }

    void Update()
    {
        if (!enabled || targetObject == null)
            return; // 스크립트가 비활성화되어 있거나 대상이 설정되지 않았으면 아무 작업도 하지 않음

        // 현재 회전 속도 계산 (정방향 또는 역방향)
        float speed = isReversing ? -rotationSpeed : rotationSpeed;

        // 회전할 각도 계산
        float rotationThisFrame = speed * Time.deltaTime;
        currentRotation += rotationThisFrame;

        // 현재 각도에 따라 회전을 멈추거나 반대 방향으로 회전 시작
        if (!isReversing && currentRotation >= stopAngle && !hasReversed)
        {
            isReversing = true; // 반대 방향으로 회전 시작
            hasReversed = true; // 역회전을 했음을 표시
        }
        else if (isReversing && currentRotation <= 0f)
        {
            isReversing = false; // 회전 중지
            currentRotation = 0f; // 정확하게 0도로 맞추기
            stop = true;
        }
        
        // 대상 오브젝트를 회전시킵니다.
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
