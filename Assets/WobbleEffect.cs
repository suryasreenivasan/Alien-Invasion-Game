using TMPro;
using UnityEngine;

public class WobbleTextEffect : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float wobbleSpeed = 2.0f;
    public float wobbleAmount = 5.0f;
    private Mesh mesh;
    private Vector3[] vertices;

    void Start()
    {
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }
    }

    void Update()
    {
        ApplyWobbleEffect();
    }

    void ApplyWobbleEffect()
    {
        textMeshPro.ForceMeshUpdate();
        mesh = textMeshPro.mesh;
        vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 offset = Wobble(Time.time + i);
            vertices[i] += offset;
        }

        mesh.vertices = vertices;
        textMeshPro.canvasRenderer.SetMesh(mesh);
    }

    Vector2 Wobble(float time)
    {
        float wobbleX = Mathf.Sin(time * wobbleSpeed) * wobbleAmount;
        float wobbleY = Mathf.Cos(time * wobbleSpeed) * wobbleAmount;
        return new Vector2(wobbleX, wobbleY);
    }
}
