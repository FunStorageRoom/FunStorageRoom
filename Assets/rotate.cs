using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialRotator : MonoBehaviour
{
    public GameObject dial; // ���̾� ��ü
    public Vector3 pivotPosition; // ���̾��� �߽ɺ� ��ġ
    public float rotationSpeed = 30.0f; // ȸ�� �ӵ� (��/��)
    public Vector3 rotationAxis = Vector3.forward; // ȸ�� �� (�⺻��: Z��)

    private GameObject pivot; // Pivot ��ü

    void Start()
    {
        // Pivot ���� �� ��ġ ����
        pivot = new GameObject("Pivot");
        pivot.transform.position = pivotPosition;

        // ���̾��� Pivot�� �ڽ����� ����
        dial.transform.parent = pivot.transform;

        // Pivot�� ��ġ�� ���̾� ��ġ�� �̵�
        pivot.transform.position = dial.transform.position;
    }

    void Update()
    {
        // ȸ�� ���� �������� Pivot�� ȸ��
        pivot.transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}