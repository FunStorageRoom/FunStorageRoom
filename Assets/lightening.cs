using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandsetGlowController : MonoBehaviour
{
    public XRSocketInteractor socketInteractor;
    public GameObject handset; // 수화기 오브젝트
    public Material glowingMaterial; // 발광 머티리얼
    public Material normalMaterial; // 일반 머티리얼
    public AudioClip audioClip; // 수화기를 들 때 재생할 오디오 클립
    public AudioClip ring;
    public AudioClip ending;
    public AudioClip middle;

    private bool haverang =false;
    private bool havetold = false;
    private bool finish = false;
    private bool isFinal = false;

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
        // AudioSource 컴포넌트 추가
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
        if (GlobalVariables.Instance.telephone && GlobalVariables.Instance.typewriter && GlobalVariables.Instance.tv1)
        {
            finish = true;
            StopAudio();
        }
    }

    private void OnHandsetRemoved(SelectExitEventArgs args)
    {
        SetHandsetGlow(true);
        if(!havetold)
        PlayAudio();
        StopAudio2();
        haverang = true;
        if(havetold&&(!GlobalVariables.Instance.typewriter || !GlobalVariables.Instance.tv1))
        {
            audioSource.clip = middle;
            PlayAudio();
        }
      
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
        havetold = true;
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

    IEnumerator PlayEndingAndTransition()
    {
        isFinal = true;
        audioSource.clip = ending;
        PlayAudio();

        yield return new WaitForSeconds(21f);
        SceneTransitionManager.singleton.GoToScene(0);
    }

    void Update()
    {
        if (GlobalVariables.Instance.telephone && GlobalVariables.Instance.typewriter && GlobalVariables.Instance.tv1 && !finish && !isFinal)
        {
            StartCoroutine(PlayEndingAndTransition());
        }
    }
}

