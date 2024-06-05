using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandsetGlowController : MonoBehaviour
{
    public XRSocketInteractor socketInteractor;
    public GameObject handset; // 수화기 오브젝트
    public Material glowingMaterial; // 발광 머티리얼
    public Material normalMaterial; // 일반 머티리얼

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

    private void OnHandsetPlaced(SelectEnterEventArgs args)
    {
        SetHandsetGlow(false);
    }

    private void OnHandsetRemoved(SelectExitEventArgs args)
    {
        SetHandsetGlow(true);
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
}
