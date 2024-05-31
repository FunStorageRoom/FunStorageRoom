using UnityEngine;

public class DialController : MonoBehaviour
{
    private bool isDragging = false;
    private float currentAngle = 0f;
    private float maxAngle = 330f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isDragging)
        {
            RotateDial();
        }
        else
        {
            ReturnToStart();
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void RotateDial()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 direction = mouseWorldPos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = (angle + 360) % 360;

        if (angle <= maxAngle)
        {
            currentAngle = angle;
            transform.rotation = Quaternion.Euler(0, 0, -currentAngle);
        }
    }

    void ReturnToStart()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 2);
        if (Quaternion.Angle(transform.rotation, Quaternion.identity) < 0.1f)
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
