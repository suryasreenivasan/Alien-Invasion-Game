using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// akshita says "we should change it from surya to cshs";;;;;
public class MainMenu : MonoBehaviour
{
   
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Debug.Log("quit called");
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public void Credits()
    {
        SceneManager.LoadScene(3);
    }
    public void NoteToLore()
    {
        SceneManager.LoadScene(4);
    }
    
    public void LoreToQuestions()
    {
        SceneManager.LoadScene(5);
    }
    
    public void ToLeaderboard()
    {
        SceneManager.LoadScene(6);
    }
}
