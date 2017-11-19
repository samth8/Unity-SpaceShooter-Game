using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{

    public GameObject[] hazards;

    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waitWave;

    public GUIText scoreText;
    public GUIText functionText;
    public GUIText gameOverText;


    private int score;
    private bool gameOver;
    private bool restart;
    private bool pause;

    void Start()
    {
        gameOver = false;
        restart = false;
        pause = false;
        functionText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !restart)
        {
            if (!pause)
            {
                Time.timeScale = 0.0f;
                functionText.text = "Press 'P' for Unpause";

            }
            else
            {
                Time.timeScale = 1.0f;
                functionText.text = "";
            }
            pause = !pause;
        }



        if (restart)
        {

            if (Input.GetKeyDown(KeyCode.R))
            {

                // Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene("Main");
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);


        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;


                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waitWave);

            if (gameOver)
            {
                functionText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }

    public bool GameIsPaused()
    {
        return pause;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }


}
