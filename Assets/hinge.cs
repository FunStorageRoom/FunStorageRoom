using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateModelOnClick : MonoBehaviour
{
    public Transform modelToRotate; // 회전할 모델의 Transform
    public float rotationDuration = 1f; // 회전 소요 시간 (초)
    public XRDirectInteractor directInteractor; // 클릭 이벤트를 받을 XR 다이렉트 인터렉터

    private bool isRotating = false; // 회전 중인지 여부
    private Quaternion startRotation; // 회전 시작 시 모델의 회전값
    private float elapsedTime; // 경과 시간

    private void Start()
    {
        // 다이렉트 인터렉터의 Select 이벤트에 핸들러 등록
        directInteractor.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!isRotating)
        {
            StartRotation();
        }
    }

    private void StartRotation()
    {
        isRotating = true;
        startRotation = modelToRotate.rotation;
        elapsedTime = 0f;
    }

    private void Update()
    {
        if (isRotating)
        {
            elapsedTime += Time.deltaTime;
            float lerpValue = elapsedTime / rotationDuration;
            if (lerpValue >= 1f)
            {
                isRotating = false;
                modelToRotate.rotation = startRotation * Quaternion.Euler(0f, 350f, 0f);
            }
            else
            {
                modelToRotate.rotation = startRotation * Quaternion.Lerp(Quaternion.identity, Quaternion.Euler(0f, 350f, 0f), lerpValue);
            }
        }
    }
}