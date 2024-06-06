using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TypeWriterBtnAction : MonoBehaviour
{
    public string character; // 버튼에 해당하는 문자
    public GameObject moveComponent;
    public bool isResetButton = false; 
    public Color pressedColor = Color.gray; // 눌렸을 때 색상
    private AudioSource audioSource;
    private Vector3 originalScale; // 버튼의 원래 스케일
    private Vector3 pressedScale; // 버튼이 눌렸을 때의 스케일
    private Vector3 originalPosition; // 버튼의 원래 위치
    private Vector3 pressedPositionOffset; // 버튼이 눌렸을 때의 위치 오프셋
    private Vector3 moveComponentOriginPosition; // 뒷 컴포넌트 오리진 위치
    private float moveDistance = 0.01f; // 타이핑 시에 이동 거리
    private float slideDuration = 0.1f; // 슬라이딩 이동 시간
    private Color originalColor; // 버튼의 원래 색상
    private Renderer buttonRenderer;
    private float pressDuration = 0.1f; // 버튼이 눌린 상태 유지 시간
    private XRSimpleInteractable interactable;
    public GameObject paperCube; // 페이퍼 오브젝트
    public float paperMoveDistance = 0.02f; // 엔터 칠 때마다 y축으로 이동할 거리
    private float angle = -7f; // x축 기준으로 기울어진 각도
    private float moveDistanceZ;
    void Start()
    {
         // 각도를 라디안으로 변환
        float angleRad = angle * Mathf.Deg2Rad;
        // z축 이동 거리를 계산
        moveDistanceZ = moveDistance * Mathf.Tan(angleRad);

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

        // "BackPart"라는 이름의 GameObject를 찾아 moveComponent로 지정
        moveComponent = GameObject.Find("BackPart");
        
        if (moveComponent != null)
        {
            moveComponentOriginPosition = moveComponent.transform.localPosition;
        }
        
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
        if(isResetButton){
              StartCoroutine(SlideBackPartToOriginalPosition());
        } else{
            MovemoveComponent();
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
    private IEnumerator SlideBackPartToOriginalPosition()
    {
        if (moveComponent != null)
        {
            Vector3 startPosition = moveComponent.transform.localPosition;
            float elapsedTime = 0f;

            while (elapsedTime < slideDuration)
            {
                moveComponent.transform.localPosition = Vector3.Lerp(startPosition, moveComponentOriginPosition, elapsedTime / slideDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            moveComponent.transform.localPosition = moveComponentOriginPosition;
            Debug.Log("Typewriter back part reset to original position.");
        }
    }
    private void MovemoveComponent()
    {
        if (moveComponent != null)
        {
            moveComponent.transform.localPosition += new Vector3(-moveDistance, 0, 0);
            Debug.Log("Typewriter back part moved left.");
        }
    }
}
