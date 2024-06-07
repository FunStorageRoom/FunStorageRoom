using UnityEngine;

public class PhoneRingController : MonoBehaviour
{
    public AudioSource phoneRingAudioSource; // 전화벨 소리 AudioSource
    public AudioClip ringClip; // 전화벨 소리 클립

    void Start()
    {
        // 전화벨 소리를 반복 재생 설정
        phoneRingAudioSource.loop = true;
        phoneRingAudioSource.clip = ringClip; // 초기 전화벨 소리 설정
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
