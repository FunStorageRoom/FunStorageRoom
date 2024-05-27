using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TypeWriterBtnAction : MonoBehaviour
{
    public string character; // 버튼에 해당하는 문자
    public Color pressedColor = Color.gray; // 눌렸을 때 색상
    private AudioSource audioSource;
    private Vector3 originalScale; // 버튼의 원래 스케일
    private Vector3 pressedScale; // 버튼이 눌렸을 때의 스케일
    private Vector3 originalPosition; // 버튼의 원래 위치
    private Vector3 pressedPositionOffset; // 버튼이 눌렸을 때의 위치 오프셋
    private Color originalColor; // 버튼의 원래 색상
    private Renderer buttonRenderer;
    private float pressDuration = 0.1f; // 버튼이 눌린 상태 유지 시간
    private XRSimpleInteractable interactable;
    void Start()
    {
        // AudioSource 컴포넌트를 추가하고 설정
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        // 정적 변수에 타이핑 소리가 설정된 경우 설정
        if (AudioClipManager.Instance != null && AudioClipManager.Instance.typingSound != null)
        {
            audioSource.clip = AudioClipManager.Instance.typingSound;
        }

        // 버튼의 원래 스케일과 위치 저장
        originalScale = transform.localScale;
        pressedScale = originalScale * 0.9f; // 스케일을 약간 줄임
        originalPosition = transform.localPosition;
        pressedPositionOffset = new Vector3(0, -0.02f, 0); // 위치를 약간 아래로 이동

        // 버튼의 원래 색상 저장
        buttonRenderer = GetComponent<Renderer>();
        if (buttonRenderer != null)
        {
            originalColor = buttonRenderer.material.color;
        }

        // XRSimpleInteractable 컴포넌트를 추가하고 설정
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnButtonPressed);

        Debug.Log("TypeWriterBtnAction Start completed");
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        Debug.Log("Button Pressed: " + character);
        
        // 타이핑 소리 재생
        if (audioSource.clip != null    )
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Typing sound is not assigned.");
        }

        // 버튼이 눌리는 애니메이션 시작
        StartCoroutine(PressButton());

        // 타이핑한 문자 화면에 출력
        if (TypewriterDisplay.Instance != null)
        {
            TypewriterDisplay.Instance.TypeCharacter(character);
        }
        else
        {
            Debug.LogWarning("TypewriterDisplay instance is not assigned.");
        }
    }

    private IEnumerator PressButton()
    {
        Debug.Log("Press Button Animation Started");

        // 버튼을 눌린 상태로 스케일, 위치, 색상 변경
        transform.localScale = pressedScale;
        transform.localPosition = originalPosition + pressedPositionOffset;
        if (buttonRenderer != null)
        {
            buttonRenderer.material.color = pressedColor;
        }

        yield return new WaitForSeconds(pressDuration);

        // 버튼을 원래 상태로 복원
        transform.localScale = originalScale;
        transform.localPosition = originalPosition;
        if (buttonRenderer != null)
        {
            buttonRenderer.material.color = originalColor;
        }

        Debug.Log("Press Button Animation Ended");
    }
}
