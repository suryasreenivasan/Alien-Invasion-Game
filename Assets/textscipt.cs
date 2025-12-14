using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class textscipt : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public Color mainColor = new Color(1.0f, 0.55f, 0.0f);
    public Color outlineColor = Color.black;
    public float outlineWidth = 0.4f;
    public float flickerSpeed = 0.1f;
    public Color flickerColor = new Color(1.0f, 1.0f, 0.88f);
    public float glowIntensity = 1.5f;
    public float dripSpeed = 1.0f;
    public float dripAmount = 3.0f;
    private Vector3 originalPosition;
    private float flickerTimer;
    void Start()
    {
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }
        
        textMeshPro.color = mainColor;
        textMeshPro.outlineColor = outlineColor;
        textMeshPro.outlineWidth = outlineWidth;
        
        originalPosition = textMeshPro.transform.position;

        textMeshPro.fontMaterial.EnableKeyword("_EMISSION");
        textMeshPro.fontMaterial.SetColor("_EmissionColor", mainColor * glowIntensity);

    }

    // Update is called once per frame
    void Update()
    {
        FlickerEffect();

        DrippingEffect();
    }

    void FlickerEffect()
    {
        flickerTimer += Time.deltaTime;
        if (flickerTimer >= flickerSpeed)
        {
            textMeshPro.color = (textMeshPro.color == mainColor) ? flickerColor : mainColor;
            flickerTimer = 0;
        }
    }

    void DrippingEffect()
    {
        float drip = Mathf.Sin(Time.time * dripSpeed) * dripAmount;
        textMeshPro.transform.position = new Vector3(originalPosition.x, originalPosition.y + drip, originalPosition.z);
    }
}
