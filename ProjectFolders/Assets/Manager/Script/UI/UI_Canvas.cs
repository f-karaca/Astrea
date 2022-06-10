using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UI_Canvas : MonoBehaviour
{
    [Header("Main Menu")]
    public GameObject mainMenu;
    public Image background;
    [Space(10)]
    public GameObject options;
    public GameObject quit;
    public GameObject pause;
    public GameObject info;
    public GameObject manaBar;
    public GameObject credits;

    int menuState;
    private bool isPause;

    public void ChangeMenu(int menuType)
    {
        menuState = menuType;
        switch (menuType)
        {
            case 1:
                mainMenu.SetActive(true);
                options.SetActive(false);
                pause.SetActive(false);
                info.SetActive(false);
                manaBar.SetActive(false);
                credits.SetActive(false);
                break;

            case 2:
                mainMenu.SetActive(false);
                options.SetActive(true);
                pause.SetActive(false);
                info.SetActive(false);
                manaBar.SetActive(false);
                credits.SetActive(false);
                break;

            case 3:
                pause.SetActive(true);
                mainMenu.SetActive(false);
                options.SetActive(false);
                info.SetActive(false);
                manaBar.SetActive(false);
                manaBar.SetActive(false);
                credits.SetActive(false);
                break;

            case 4:
                mainMenu.SetActive(false);
                options.SetActive(false);
                pause.SetActive(false);
                info.SetActive(false);
                manaBar.SetActive(false);
                credits.SetActive(true);
                break;

            default:
                break;
        }

    }


    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void PauseMenu()
    {
        isPause = !isPause;
        if (isPause)
        {
            OpenPause();
        }
        else
        {
            ClosePause();
        }

    }

    public void QuitGame()
    {
        Application.Quit();
        
    }

    public void OpenPause()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        //pause.SetActive(true);
        ChangeMenu(3);
    }

    public void ClosePause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        pause.SetActive(false);
        manaBar.SetActive(true);
    }

    public void SetActiveInfo(bool value)
    {
        info.SetActive(value);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
