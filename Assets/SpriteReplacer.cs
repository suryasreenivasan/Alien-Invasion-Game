using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public SpriteRenderer sprite1;
    public SpriteRenderer sprite2;
    public SpriteRenderer sprite3;
    public Sprite newSprite1;
    public Sprite newSprite2;
    public Sprite newSprite3;
    private PointManager pointManager;
    private bool sprite1Changed = false;
    private bool sprite2Changed = false;
    private bool sprite3Changed = false;

    void Start()
    {
        pointManager = FindObjectOfType<PointManager>();
    }

    void Update()
    {
        int currentScore = pointManager.score;

        if (currentScore >= 250 && !sprite1Changed)
        {
            sprite1.sprite = newSprite1;
            sprite1Changed = true;
        }

        if (currentScore >= 500 && !sprite2Changed)
        {
            sprite2.sprite = newSprite2;
            sprite2Changed = true;
        }

        if (currentScore >= 1000 && !sprite3Changed)
        {
            sprite3.sprite = newSprite3;
            sprite3Changed = true;
        }
    }
}
