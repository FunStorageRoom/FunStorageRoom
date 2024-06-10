using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PopupDisabler : MonoBehaviour
{
    private XRSimpleInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.activated.AddListener(OnActivated);
    }

    private void OnActivated(ActivateEventArgs arg)
    {
        gameObject.SetActive(false);
    }
    
    void OnDestroy()
    {
        interactable.activated.RemoveListener(OnActivated);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
