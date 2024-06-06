using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandsetGlowController : MonoBehaviour
{
    public XRSocketInteractor socketInteractor;
    public GameObject handset; // ��ȭ�� ������Ʈ
    public Material glowingMaterial; // �߱� ��Ƽ����
    public Material normalMaterial; // �Ϲ� ��Ƽ����
    public AudioClip audioClip; // ��ȭ�⸦ �� �� ����� ����� Ŭ��

    private AudioSource audioSource;

    private void OnEnable()
    {
        socketInteractor.selectEntered.AddListener(OnHandsetPlaced);
        socketInteractor.selectExited.AddListener(OnHandsetRemoved);
    }

    private void OnDisable()
    {
        socketInteractor.selectEntered.RemoveListener(OnHandsetPlaced);
        socketInteractor.selectExited.RemoveListener(OnHandsetRemoved);
    }

    private void Start()
    {
        // AudioSource ������Ʈ �߰�
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.playOnAwake = false;
    }

    private void OnHandsetPlaced(SelectEnterEventArgs args)
    {
        SetHandsetGlow(false);
        StopAudio();
    }

    private void OnHandsetRemoved(SelectExitEventArgs args)
    {
        SetHandsetGlow(true);
        PlayAudio();
    }

    private void SetHandsetGlow(bool shouldGlow)
    {
        if (shouldGlow)
        {
            handset.GetComponent<Renderer>().material = glowingMaterial;
        }
        else
        {
            handset.GetComponent<Renderer>().material = normalMaterial;
        }
    }

    private void PlayAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void StopAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}

