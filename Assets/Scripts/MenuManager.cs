using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject creditsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("LevelScene");
    }
   
    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }
       
    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
       
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
       
       
}