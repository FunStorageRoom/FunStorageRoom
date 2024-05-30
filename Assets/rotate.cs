using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialRotator : MonoBehaviour
{
    public GameObject dial; // 다이얼 객체
    public Vector3 pivotPosition; // 다이얼의 중심부 위치
    public float rotationSpeed = 30.0f; // 회전 속도 (도/초)
    public Vector3 rotationAxis = Vector3.forward; // 회전 축 (기본값: Z축)

    private GameObject pivot; // Pivot 객체

    void Start()
    {
        // Pivot 생성 및 위치 설정
        pivot = new GameObject("Pivot");
        pivot.transform.position = pivotPosition;

        // 다이얼을 Pivot의 자식으로 설정
        dial.transform.parent = pivot.transform;

        // Pivot의 위치를 다이얼 위치로 이동
        pivot.transform.position = dial.transform.position;
    }

    void Update()
    {
        // 회전 축을 기준으로 Pivot을 회전
        pivot.transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}