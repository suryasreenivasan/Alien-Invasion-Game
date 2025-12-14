using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PulseEffect : MonoBehaviour
{

    public TextMeshProUGUI textMeshPro;
    public float pulseSpeed = 1.0f;
    public float pulseAmount = 0.1f;
    private Vector3 originalScale;
    // Start is called before the first frame update
    void Start()
    {
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }

        originalScale = textMeshPro.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float scaleFactor = Mathf.Sin(Time.time * pulseSpeed) * pulseAmount + 1.0f;
        textMeshPro.transform.localScale = originalScale * scaleFactor;
    }
}
