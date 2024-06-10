using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class PanelActivator : MonoBehaviour
{
    public GameObject panel;
    private XRSimpleInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.activated.AddListener(OnActivated);
    }

    private void OnActivated(ActivateEventArgs arg)
    {
        panel.SetActive(!panel.activeSelf);
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
