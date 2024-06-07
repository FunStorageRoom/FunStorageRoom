using UnityEngine;
using TMPro;

public class TypewriterDisplay : MonoBehaviour
{
    public static TypewriterDisplay Instance;
    public TextMeshProUGUI displayText; // 화면에 표시할 텍스트

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TypeCharacter(string character)
    {
        displayText.text += character;
    }
}
