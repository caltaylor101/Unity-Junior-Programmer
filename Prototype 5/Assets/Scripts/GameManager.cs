using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreText; 
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score = 0;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive = true;
    public Button restartButton; 
    public GameObject titleScreen;
    void Start()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score; 
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true); 
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty; 
        score = 0;
        UpdateScore(0); 
        StartCoroutine(SpawnTarget());
        scoreText.text = "Score: " + score;
        titleScreen.SetActive(false); 
    }
}
