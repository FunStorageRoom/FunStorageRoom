using UnityEngine;

public class PhoneReceiver : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip tts; // 시계방향 회전 중 재생할 오디오 클립

    void Start()
    {
        // 오디오 소스 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();
    }

    // 수화기를 들었을 때 호출될 함수
    public void PickUpReceiver()
    {
        // 오디오 재생
        if (!audioSource.isPlaying)
        {
            audioSource.clip = tts;
            audioSource.Play();
        }
    }

    // 수화기를 놓을 때 호출될 함수 (필요한 경우)
    public void HangUpReceiver()
    {
        // 오디오 정지
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
