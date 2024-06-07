using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandsetGlowController : MonoBehaviour
{
    public XRSocketInteractor socketInteractor;
    public GameObject handset; // ��ȭ�� ������Ʈ
    public Material glowingMaterial; // �߱� ��Ƽ����
    public Material normalMaterial; // �Ϲ� ��Ƽ����
    public AudioClip audioClip; // ��ȭ�⸦ �� �� ����� ����� Ŭ��
    public AudioClip ring;
    private bool haverang =false;

    private AudioSource audioSource;
    private AudioSource audioSource2;

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
        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = ring;
        audioSource2.playOnAwake = true;
        audioSource.clip = audioClip;
        audioSource.playOnAwake = false;
    }

    private void OnHandsetPlaced(SelectEnterEventArgs args)
    {
        SetHandsetGlow(false);
        StopAudio();
        if(!haverang)
        PlayAudio2();
    }

    private void OnHandsetRemoved(SelectExitEventArgs args)
    {
        SetHandsetGlow(true);
        PlayAudio();
        StopAudio2();
        haverang = true;
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
    private void PlayAudio2()
    {
        if (!audioSource2.isPlaying)
        {
            audioSource2.Play();
        }
    }

    private void StopAudio2()
    {
        if (audioSource2.isPlaying)
        {
            audioSource2.Stop();
        }
    }
}

