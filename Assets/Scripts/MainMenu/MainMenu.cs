using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        Debug.Log("Começou");
        SceneManager.LoadScene(1);
    }

    public void ExitGame(){
        Debug.Log("Game has quitted");
        Application.Quit();
    }
}
