using UnityEngine;

public class AudioClipManager : MonoBehaviour
{
    public static AudioClipManager Instance { get; private set; }
    public AudioClip typingSound; // 에셋 내에서 한 번만 할당할 타이핑 소리

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 이 오브젝트를 씬 전환 시에도 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
