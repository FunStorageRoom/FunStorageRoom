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
        interactable.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs arg)
    {
        panel.SetActive(!panel.activeSelf);
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
