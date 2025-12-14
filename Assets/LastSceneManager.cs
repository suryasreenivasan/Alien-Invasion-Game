using UnityEngine;
using TMPro;

public class LastSceneManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public Sprite spriteD;
    public Sprite spriteE;
    public Sprite spriteF;
    public SpriteRenderer spriteRendererA;
    public SpriteRenderer spriteRendererB;
    public SpriteRenderer spriteRendererC;
    private int score;

    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        scoreText.text = "YOUR SCORE: " + score;
        UpdateSprites();
    }

    void UpdateSprites()
    {
        if (score >= 250)
        {
            spriteRendererA.sprite = spriteD;
        }

        if (score >= 500)
        {
            spriteRendererB.sprite = spriteE;
        }

        if (score >= 1000)
        {
            spriteRendererC.sprite = spriteF;
        }
    }
}
