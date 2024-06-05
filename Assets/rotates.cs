using UnityEngine;

public class RotateEarth : MonoBehaviour
{
    public Transform targetObject; // ȸ����ų ��� ������Ʈ�� Transform
    public float rotationSpeed = 10f; // ������Ʈ�� ȸ�� �ӵ� (degrees per second)
    public float stopAngle = 90f; // ȸ���� ���� ����
    public AudioClip rotationAudio; // ȸ�� �� ����� ����� Ŭ��

    private float currentRotation = 0f; // ���� ȸ���� ����
    private float targetRotation = 0f; // ��ǥ ȸ�� ����
    private bool isReversing = false; // �ݴ� �������� ȸ�� ������ Ȯ���ϴ� �÷���
    private bool stop = false;
    private bool rotating = false; // ȸ�� ������ ���θ� ��Ÿ���� �÷���

    private AudioSource audioSource; // ����� �ҽ� ������Ʈ

    private void Start()
    {
        // AudioSource ������Ʈ�� �������ų� ���� �߰�
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void StartRotation()
    {
        rotating = true; // ȸ�� ����
        stop = false;
        targetRotation = stopAngle; // ��ǥ ȸ�� ���� ����

        // ȸ�� ����� ���
        audioSource.clip = rotationAudio;
        audioSource.Play();
    }

    void StopRotation()
    {
        rotating = false; // ȸ�� ����
        stop = true;
        audioSource.Stop(); // ����� ��� ����
    }

    void Update()
    {
        if (!rotating || targetObject == null)
            return; // ȸ�� ���� �ƴϰų� ����� �������� �ʾ����� �ƹ� �۾��� ���� ����

        // ���� ȸ�� �ӵ� ��� (������ �Ǵ� ������)
        float speed = isReversing ? -rotationSpeed : rotationSpeed;
        // ȸ���� ���� ���
        float rotationThisFrame = speed * Time.deltaTime;
        currentRotation += rotationThisFrame;

        // ���� ������ ���� ȸ���� ���߰ų� �ݴ� �������� ȸ�� ����
        if (!isReversing && currentRotation >= targetRotation)
        {
            isReversing = true; // �ݴ� �������� ȸ�� ����
            targetRotation = 0f; // ��ǥ ȸ�� ������ 5�� �� ȸ���� ���·� ����
        }
        else if (isReversing && currentRotation <= targetRotation)
        {
            isReversing = false; // ȸ�� ����
            currentRotation = 0f; // ��Ȯ�ϰ� 0���� ���߱�
            StopRotation(); // ȸ�� ����
        }

        // ��� ������Ʈ�� ȸ����ŵ�ϴ�.
        targetObject.Rotate(Vector3.up, rotationThisFrame);
    }
}
