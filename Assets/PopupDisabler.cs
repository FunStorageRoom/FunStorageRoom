using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PopupDisabler : MonoBehaviour
{
    private XRSimpleInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs arg)
    {
        gameObject.SetActive(false);
    }
    
    void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnSelectEntered);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
