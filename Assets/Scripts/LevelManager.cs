using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private Ball ball;
    private GameObject canvasUI;
    private GameObject canvasMe;



    private void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        canvasUI = GameObject.FindGameObjectWithTag("UICanvas");
        canvasMe = GameObject.FindGameObjectWithTag("MenuCanvas");
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            canvasMe.SetActive(false);
        }

    }


    //private void Update()
    //{
    //    print(ball.inPlay);
    //}

    public void LoadNextLevel()
    {
        int y = SceneManager.GetActiveScene().buildIndex +1;
        SceneManager.LoadScene(y);
        Debug.Log("Loaded scene with index: " + (y));
    }


    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }


    // my function for paused game
    public void PausedGame()
    {
        
        
        
        

        ball.inPlay = true;
        canvasUI.SetActive(false);
        canvasMe.SetActive(true);
    }


    public void ResumeButton()
    {
        ball.inPlay = false;
        canvasUI.SetActive(true);
        canvasMe.SetActive(false);
    }


    public void PlayAgainButton()
    {
        // index 1 beacuse build index of game scene = 1
        SceneManager.LoadScene(1);
    }


    public void MainMenuButton()
    {
        // index 0 because build index of main menu scene = 0
        SceneManager.LoadScene(0);
    }

}