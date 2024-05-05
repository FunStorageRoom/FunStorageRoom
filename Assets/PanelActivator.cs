using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PanelActivator : MonoBehaviour
{
    public GameObject panel;
    private XRGrabInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnSelectEntered);
        interactable.selectExited.AddListener(OnSelectExited);
        
    }
    private void OnSelectEntered(SelectEnterEventArgs arg)
    {
        panel.SetActive(true);
    }
    private void OnSelectExited(SelectExitEventArgs arg)
    {
        panel.SetActive(false);

    }
    void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnSelectEntered);
        interactable.selectExited.RemoveListener(OnSelectExited);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
