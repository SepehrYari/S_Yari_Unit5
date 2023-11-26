using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const float SpawnRate = 2.0f;
    public List<GameObject> prefabs;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI gameOverText;
    public Button RestartButton;
    private int score = 0;
    public bool GameActive = true;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);

    }

    public void GameOver()
    {
        GameActive = false;
        gameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
    }

    IEnumerator SpawnTarget()
    {
        while (GameActive)
        {
            yield return new WaitForSeconds(SpawnRate);
            Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
            
        }
    }

    public void UpdateScore(int scoreData)
    {
        score += scoreData;
        if(score< 0)
        {
            score = 0;
        }
        ScoreText.text = "Score: " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
