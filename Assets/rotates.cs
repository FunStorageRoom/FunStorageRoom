using UnityEngine;

public class RotateEarth : MonoBehaviour
{
    public Transform targetObject; // 회전시킬 대상 오브젝트의 Transform
    public float rotationSpeed = 10f; // 오브젝트의 회전 속도 (degrees per second)
    public float stopAngle = 90f; // 회전을 멈출 각도
    public AudioClip rotationAudio; // 회전 중 재생할 오디오 클립

    private float currentRotation = 0f; // 현재 회전된 각도
    private float targetRotation = 0f; // 목표 회전 각도
    private bool isReversing = false; // 반대 방향으로 회전 중인지 확인하는 플래그
    private bool stop = false;
    private bool rotating = false; // 회전 중인지 여부를 나타내는 플래그

    private AudioSource audioSource; // 오디오 소스 컴포넌트

    private void Start()
    {
        // AudioSource 컴포넌트를 가져오거나 새로 추가
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void StartRotation()
    {
        rotating = true; // 회전 시작
        stop = false;
        targetRotation = stopAngle; // 목표 회전 각도 설정

        // 회전 오디오 재생
        audioSource.clip = rotationAudio;
        audioSource.Play();
    }

    void StopRotation()
    {
        rotating = false; // 회전 중지
        stop = true;
        audioSource.Stop(); // 오디오 재생 중지
    }

    void Update()
    {
        if (!rotating || targetObject == null)
            return; // 회전 중이 아니거나 대상이 설정되지 않았으면 아무 작업도 하지 않음

        // 현재 회전 속도 계산 (정방향 또는 역방향)
        float speed = isReversing ? -rotationSpeed : rotationSpeed;
        // 회전할 각도 계산
        float rotationThisFrame = speed * Time.deltaTime;
        currentRotation += rotationThisFrame;

        // 현재 각도에 따라 회전을 멈추거나 반대 방향으로 회전 시작
        if (!isReversing && currentRotation >= targetRotation)
        {
            isReversing = true; // 반대 방향으로 회전 시작
            targetRotation = 0f; // 목표 회전 각도를 5도 더 회전한 상태로 설정
        }
        else if (isReversing && currentRotation <= targetRotation)
        {
            isReversing = false; // 회전 중지
            currentRotation = 0f; // 정확하게 0도로 맞추기
            StopRotation(); // 회전 중지
        }

        // 대상 오브젝트를 회전시킵니다.
        targetObject.Rotate(Vector3.up, rotationThisFrame);
    }
}
