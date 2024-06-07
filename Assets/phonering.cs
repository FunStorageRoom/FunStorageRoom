using UnityEngine;

public class PhoneRingController : MonoBehaviour
{
    public AudioSource phoneRingAudioSource; // ��ȭ�� �Ҹ� AudioSource
    public AudioClip ringClip; // ��ȭ�� �Ҹ� Ŭ��

    void Start()
    {
        // ��ȭ�� �Ҹ��� �ݺ� ��� ����
        phoneRingAudioSource.loop = true;
        phoneRingAudioSource.clip = ringClip; // �ʱ� ��ȭ�� �Ҹ� ����
    }

    public void StartRinging()
    {
        if (!phoneRingAudioSource.isPlaying)
        {
            phoneRingAudioSource.Play();
        }
    }

    public void StopRinging()
    {
        if (phoneRingAudioSource.isPlaying)
        {
            phoneRingAudioSource.Stop();
        }
    }
}
