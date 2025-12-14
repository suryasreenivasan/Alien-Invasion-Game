using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InputScore : MonoBehaviour
{
    public TMP_Text scoreText;
    [SerializeField]
    private int inputScore;
    [SerializeField]
    private TMP_InputField inputName;
    public UnityEvent<string, int> submitScoreEvent;

    // Start is called before the first frame update
    void Start()
    {
        inputScore = PlayerPrefs.GetInt("score", 0);
        PlayerPrefs.DeleteKey("score");
        PlayerPrefs.Save();
        scoreText.text = "YOUR SCORE: " + inputScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, inputScore);
    }
}
