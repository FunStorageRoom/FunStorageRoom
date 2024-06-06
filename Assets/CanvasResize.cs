using UnityEngine;

public class CanvasSizeAdjuster : MonoBehaviour
{
    public Canvas canvas; // Canvas를 연결할 변수
    public GameObject parentObject; // 부모 GameObject를 연결할 변수

    void Start()
    {
        if (canvas != null && parentObject != null)
        {
            AdjustCanvasSize();
        }
        else
        {
            Debug.LogWarning("Canvas or Parent Object is not assigned.");
        }
    }

    void AdjustCanvasSize()
    {
        // 부모 오브젝트의 크기 가져오기
        Vector3 parentSize = parentObject.GetComponent<Renderer>().bounds.size;

        // Canvas의 RectTransform 가져오기
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();

        // 부모 오브젝트의 크기에 맞추어 Canvas 크기 조정
        canvasRect.sizeDelta = new Vector2(parentSize.x, parentSize.y);
        
        // 부모 오브젝트의 위치에 맞추어 Canvas 위치 조정
        canvasRect.position = parentObject.transform.position;

        // 부모 오브젝트의 회전에 맞추어 Canvas 회전 조정
        canvasRect.rotation = parentObject.transform.rotation;
    }
}
