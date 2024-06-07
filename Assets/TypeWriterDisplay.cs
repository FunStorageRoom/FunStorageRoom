using UnityEngine;
using TMPro;

public class TypewriterDisplay : MonoBehaviour
{
    public static TypewriterDisplay Instance;
    public TextMeshPro displayText; // 화면에 표시할 텍스트

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TypeCharacter(string character)
    {
        if(displayText != null)
        {
            displayText.text += character;
        } else
        {
            Debug.LogWarning("displayText가 설정 안되었습니다.");
        }
    }
}
