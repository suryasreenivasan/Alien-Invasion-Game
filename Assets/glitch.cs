using System.Collections;
using UnityEngine;
using TMPro;

public class TextDistortion : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public float distortionAmount = 0.1f;
    public float distortionSpeed = 1.0f;
    public float distortionDuration = 0.5f;
    public float waitTime = 1.0f;

    private Vector3[] originalVertices;

    void Start()
    {
        if (textMeshPro == null)
            textMeshPro = GetComponent<TMP_Text>();

        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshPro component is not assigned or found. Please assign it in the Inspector or ensure this script is on a GameObject with TMP.");
            return;
        }

        if (string.IsNullOrEmpty(textMeshPro.text))
        {
            Debug.LogError("TextMeshPro text is empty. Please assign text to distort.");
            return;
        }

        textMeshPro.ForceMeshUpdate();
        originalVertices = textMeshPro.textInfo.meshInfo[0].vertices;
        StartCoroutine(ApplyDistortion());
    }

    private IEnumerator ApplyDistortion()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            if (textMeshPro.textInfo.meshInfo.Length > 0 && textMeshPro.textInfo.meshInfo[0].vertices.Length > 0)
            {
                Vector3[] vertices = new Vector3[textMeshPro.textInfo.meshInfo[0].vertices.Length];
                textMeshPro.textInfo.meshInfo[0].vertices.CopyTo(vertices, 0);

                for (int i = 0; i < vertices.Length; i++)
                {
                    vertices[i].y += Mathf.Sin(Time.time * distortionSpeed + i) * distortionAmount;
                }

                textMeshPro.textInfo.meshInfo[0].vertices = vertices;
                textMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
                yield return new WaitForSeconds(distortionDuration);
                textMeshPro.textInfo.meshInfo[0].vertices = originalVertices;
                textMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
            }
            else
            {
                Debug.LogError("Mesh info or vertices are not available. Please check if the text is correctly rendered.");
                yield break;
            }
        }
    }
}
