using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using unityengine.UI because I am linking to UI elements(buttons).

public class MainMenu : MonoBehaviour {
    //this is my start game function
    public void Startgame()
    {
        //this simply loads the scene of build index 1 which is my 'game'.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Exitgame()
    {
        //this closes the application.
        Application.Quit();
    }

}
