using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateModelOnClick : MonoBehaviour
{
    public Transform modelToRotate; // ȸ���� ���� Transform
    public float rotationDuration = 1f; // ȸ�� �ҿ� �ð� (��)
    public XRDirectInteractor directInteractor; // Ŭ�� �̺�Ʈ�� ���� XR ���̷�Ʈ ���ͷ���

    private bool isRotating = false; // ȸ�� ������ ����
    private Quaternion startRotation; // ȸ�� ���� �� ���� ȸ����
    private float elapsedTime; // ��� �ð�

    private void Start()
    {
        // ���̷�Ʈ ���ͷ����� Select �̺�Ʈ�� �ڵ鷯 ���
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