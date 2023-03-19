using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public PlayerCotroller playerCotroller;
    public GameObject startMenu,gameMenu,gameOverMenu,NextLevelMenu,finishMenu,stopButton,startButton;
    public Animator animator;
    public GameObject pS;
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    public void StartLevel()
    {
        playerCotroller.isPlayerMoved= true;
        startMenu.SetActive(false);
        gameMenu.SetActive(true);
        animator.SetBool("running", true);
        

    }
    public void RetryButton()
    {
       
        SceneManager.LoadScene("level 0");
        Time.timeScale = 1;
    }
    public void RetryButton2()
    {

        SceneManager.LoadScene("level 1");
        Time.timeScale = 1;
    }
    public void StopButton()
    {
        Time.timeScale = 0;
        stopButton.SetActive(false);
        startButton.SetActive(true);
    }
    public void ContinueButton()
    {
        Time.timeScale = 1;
        startButton.SetActive(false);
        stopButton.SetActive(true);
    }
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("çýktýk");
    }
    public void NextLevelButton()
    {
        SceneManager.LoadScene("level 1");
    }

}
