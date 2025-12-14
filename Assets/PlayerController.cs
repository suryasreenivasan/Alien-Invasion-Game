using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float horizontalInput = 0;
    public int lives = 3;
    public Image[] livesUI;
    public GameObject explosionPrefab;

    public AudioSource audioSource;
    public AudioClip musicForThreeLives;
    public AudioClip musicForTwoLives;
    public AudioClip musicForOneLife;
    public AudioClip musicForZeroLives;

    void Start()
    {
        lives = PlayerPrefs.GetInt("lives", PlayerPrefs.GetInt("correctAnswersCount", 3));
        UpdateLivesUI();
        PlayMusicBasedOnLives();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "enemy")
        {
            Destroy(collision.collider.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            lives -= 1;
            PlayerPrefs.SetInt("lives", lives);
            UpdateLivesUI();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy projectile")
        {
            Destroy(collision.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            lives -= 1;
            PlayerPrefs.SetInt("lives", lives);
            UpdateLivesUI();
        }
    }

    public void UpdateLivesUI()
    {
        int uiLength = livesUI.Length;

        for (int i = 0; i < uiLength; i++)
        {
            if (i < lives)
            {
                livesUI[i].enabled = true;
            }
            else
            {
                livesUI[i].enabled = false;
            }
        }

        if (lives <= 0)
        {
            Debug.Log("Player has died. Preparing to load end scene.");
            PlayerPrefs.DeleteKey("lives");
            PlayerPrefs.Save();
            DisablePlayer();
            StartCoroutine(LoadEndSceneAfterDelay(5f));
        }

        PlayMusicBasedOnLives();
    }

    private void DisablePlayer()
    {
        Vector3 position = transform.position;
        position.y = 5000;
        transform.position = position;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        enabled = false;
    }

    private void PlayMusicBasedOnLives()
    {
        if (lives == 3)
        {
            audioSource.clip = musicForThreeLives;
        }
        else if (lives == 2)
        {
            audioSource.clip = musicForTwoLives;
        }
        else if (lives == 1)
        {
            audioSource.clip = musicForOneLife;
        }
        else if (lives <= 0)
        {
            audioSource.clip = musicForZeroLives;
        }

        audioSource.Play();
    }

    private IEnumerator LoadEndSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("end");
    }
}
