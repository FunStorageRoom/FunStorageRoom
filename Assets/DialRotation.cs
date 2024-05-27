using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialRotation : MonoBehaviour
{

    public Transform dial; // This field should appear in the Inspector
    public float maxRotationAngle = 270f;
    public float rotationSpeed = 100f;
    private bool isRotating = false;
    private float startAngle;
    private float currentAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == dial)
                {
                    isRotating = true;
                    startAngle = GetMouseAngle();
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            float mouseAngle = GetMouseAngle();
            float angleDifference = mouseAngle - startAngle;
            currentAngle = Mathf.Clamp(currentAngle + angleDifference, 0, maxRotationAngle);
            dial.localEulerAngles = new Vector3(0, 0, -currentAngle);
            startAngle = mouseAngle;
        }
    }

    private float GetMouseAngle()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(dial.position);
        Vector2 direction = new Vector2(Input.mousePosition.x - screenPos.x, Input.mousePosition.y - screenPos.y);
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }
}
