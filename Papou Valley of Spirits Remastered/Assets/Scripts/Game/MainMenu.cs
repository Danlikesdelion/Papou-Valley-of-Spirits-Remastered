using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;

    public GameObject creditsWindow;
    [SerializeField] private AudioSource buttonclickopen;
    [SerializeField] private AudioSource buttonclickclose;

    public void StartGame()
    {
        buttonclickopen.Play();
        SceneManager.LoadScene(levelToLoad);
    }

    public void OpenCreditsWindow()
    {
        buttonclickopen.Play();
        creditsWindow.SetActive(true);
    }

    public void CloseCreditsSWindow()
    {
        buttonclickclose.Play();
        creditsWindow.SetActive(false);
    }

    public void QuitGame()
    {
        buttonclickclose.Play();
        Application.Quit();
    }
}
