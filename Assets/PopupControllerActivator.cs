using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class PopupControllerActivator : MonoBehaviour
{
    public GameObject popupScreen;
    public InputActionProperty triggerAnimation;

    private bool isPopupActivate = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = triggerAnimation.action.ReadValue<float>();
        if(triggerValue > 0.1f)
        {
            isPopupActivate = !isPopupActivate;
            popupScreen.SetActive(isPopupActivate);
        }
    }
}
