﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public int numberOfBricks;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("BrickRed").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;

        // chenck for no lives left game over
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        livesText.text = "Lives: " + lives;
    }
    public void UpdateScore (int points)
    {
        score += points;
        scoreText.text = "Score " + score;

    }

    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if (numberOfBricks <= 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Quit ()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
