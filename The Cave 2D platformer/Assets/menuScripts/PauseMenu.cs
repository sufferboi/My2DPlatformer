using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    //array which tells game that game paused is false upon starting game.
    public static bool GamePaused = false;

    //allows you to access gameobjects publically.
    public GameObject PauseMenuUI;
    
    public void Resume()
    {

    }



    //method that is called upon every frame.
    void Update()
    {
        //this binds the key 'escape' to the 'Gamepaused' function.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        //disbales the 'PauseMenu'.
        PauseMenuUI.SetActive(false);
        //unfreezes the game.
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void pause()
    {
        //Simply activates 'PauseMenu'.
        PauseMenuUI.SetActive(true);
        //this freezes the main camera so your progress cannot be affected whilst 'PauseMenu' is enabled.
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void LoadMenu()
    {
        //loads the scene named 'mainmenu'.
        SceneManager.LoadScene("mainmenu");
    }

    public void Exitgame()
    {
        //closes the application.
        Application.Quit();
    }
}
