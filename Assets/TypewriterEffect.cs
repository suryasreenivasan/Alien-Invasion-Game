using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    [TextArea(3, 10)]
    public string fullText;
    public float typingSpeed = 0.05f;

    private TextMeshProUGUI textComponent;
    private string currentText = ""; 

    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        foreach (char letter in fullText)
        {
            currentText += letter;
            textComponent.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
