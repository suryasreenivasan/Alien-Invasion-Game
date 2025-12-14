using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonDelayedAppearance : MonoBehaviour
{
    public TextMeshProUGUI buttonText; 
    public Button button;
    public float delayTime = 30.0f;

    private void Start()
    {
        Color buttonColor = buttonText.color;
        buttonColor.a = 0;
        buttonText.color = buttonColor;
        button.interactable = false;
        StartCoroutine(ShowButtonAfterDelay());
    }

    private IEnumerator ShowButtonAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);

        Color buttonColor = buttonText.color;
        buttonColor.a = 1;
        buttonText.color = buttonColor;
        button.interactable = true;
    }
}
