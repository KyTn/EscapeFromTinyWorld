using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashControllerUI : MonoBehaviour {


    public Button playbutton;

    public GameObject Credits;
    public GameObject HowTo;

    public Button backcreditsbutton;
    public Button backHowTobutton;

    // Use this for initialization
    void Start () {
        EventSystem.current.SetSelectedGameObject(playbutton.gameObject);
	}
	

    public void LaunchCredits()
    {
        Credits.SetActive(true);
        EventSystem.current.SetSelectedGameObject(backcreditsbutton.gameObject);
    }

    public void BackMainMenu()
    {
        HowTo.SetActive(false);
        Credits.SetActive(false);
        EventSystem.current.SetSelectedGameObject(playbutton.gameObject);
    }


    public void QuitGame()
    {
        Application.Quit();
    }


    public void GotoPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void showHowTo()
    {
        HowTo.SetActive(true);
        EventSystem.current.SetSelectedGameObject(backHowTobutton.gameObject);
    }
}
