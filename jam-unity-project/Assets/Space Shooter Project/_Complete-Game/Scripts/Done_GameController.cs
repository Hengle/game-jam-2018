using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Done_GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private bool gameOver;
    private bool restart;
    private int score;
    
    void Start()
    {
        gameOver = false;
        restart = false;
        
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        StartCoroutine(HightProgression());
        StartCoroutine(HightSPAWN());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator HightProgression()
    {
        spawnWait -= 2f;
        
        yield return new WaitForSeconds(1);
    }
    
    IEnumerator HightSPAWN()
    {
        yield return new WaitForSeconds(35);
        
        hazardCount += 20;
        
        yield return new WaitForSeconds(1);
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait * 2);
        while (true)
        {
            for (var i = 0; i < hazardCount; i++)
            {
                var hazard = hazards[Random.Range(0, hazards.Length)];
                var spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                
                var asd = Instantiate(hazard, transform);
                asd.transform.localPosition = spawnPosition;
                
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        //scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
       // gameOverText.text = "Game Over!";
        gameOver = true;
    }
}