using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckChildrenAndLoadScene : MonoBehaviour
{
    public string sceneToLoad;
    private float timer = 10f;
    private bool noChildren = false;

    void Update()
    {
        
        if (transform.childCount == 0 && !noChildren)
        {
            noChildren = true;
        }

        if (noChildren)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
