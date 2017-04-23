using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameControllerUI : MonoBehaviour {


    public GameObject HUDPanel;

    public GameObject LosePanel;
    public Image backgroundLose;
    public Button backToMainMenuWhenLose;
    public Text score;




    public GameObject WinPanel;
    public Button backToMainMenuWhenWin;

    public GameManager.GameManagerState state;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.instance.state == GameManager.GameManagerState.LOSE && GameManager.instance.state != state)
        {
            state = GameManager.GameManagerState.LOSE;
            ActivateLosePanel();
        }

        if (GameManager.instance.state == GameManager.GameManagerState.WIN && GameManager.instance.state != state)
        {
            state = GameManager.GameManagerState.WIN;
            ActivateWinPanel();
        }
    }





    public void ActivateLosePanel()
    {
        LosePanel.SetActive(true);
        //backgroundLose.color = new Color(0, 0, 0, 0);
        backgroundLose.DOColor(new Color(0, 0, 0, 1), 2f);


        int m = (int)GameManager.instance.TimeToColapse / 60;
        int s = (int)GameManager.instance.TimeToColapse - (m * 60);

        score.text = "Gems: " + GameManager.instance.GemsTouched + "\nTime Left: "+ (m < 10 ? "0" + m : "" + m) + ":" + (s < 10 ? "0" + s : "" + s);

        EventSystem.current.SetSelectedGameObject(backToMainMenuWhenLose.gameObject);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public void ActivateWinPanel()
    {
        WinPanel.SetActive(true);
        //backgroundLose.color = new Color(0, 0, 0, 0);
        //backgroundLose.DOColor(new Color(0, 0, 0, 1), 2f);
        HUDPanel.SetActive(false);

        
        EventSystem.current.SetSelectedGameObject(backToMainMenuWhenWin.gameObject);
    }

}
