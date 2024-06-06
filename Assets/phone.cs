using UnityEngine;

public class PhoneReceiver : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip tts; // �ð���� ȸ�� �� ����� ����� Ŭ��

    void Start()
    {
        // ����� �ҽ� ������Ʈ ��������
        audioSource = GetComponent<AudioSource>();
    }

    // ��ȭ�⸦ ����� �� ȣ��� �Լ�
    public void PickUpReceiver()
    {
        // ����� ���
        if (!audioSource.isPlaying)
        {
            audioSource.clip = tts;
            audioSource.Play();
        }
    }

    // ��ȭ�⸦ ���� �� ȣ��� �Լ� (�ʿ��� ���)
    public void HangUpReceiver()
    {
        // ����� ����
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
