using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMC : MonoBehaviour
{
    public GameObject MenuCamera;
    public GameObject PlayerCamera;
    public GameObject PauseScreen;
    public bool TogglePauseMenu = false;
    public AudioSource BGM;
    public GameObject LoseScreen;
    public GameObject WinScreen;
    public AudioSource audioSource;
    public AudioClip WinSFX;
    public AudioClip LoseSFX;
    bool DoOnce = false;
    static bool EnableBGM = true;


    void Awake()
    {
        MenuCamera.SetActive(true);
        PlayerCamera.SetActive(false);
        MouseEnable();
        if (EnableBGM == true)
        {
            DontDestroyOnLoad(BGM);
            BGM.Play();
            EnableBGM = false;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && TogglePauseMenu == false)
        {
            PauseGame();
            TogglePauseMenu = true;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && TogglePauseMenu == true)
        {
            ResumeGame();
            TogglePauseMenu = false;
        }
    }

    public void StartGame()
    {
        MenuCamera.SetActive(false);
        PlayerCamera.SetActive(true);
        MouseDisable();
    }

    public void MainMenu()
    {
        MenuCamera.SetActive(true);
        PlayerCamera.SetActive(false);
        MouseEnable();
    }

    public void Restart()
    {
         SceneManager.LoadScene("Stage");
    }
    public void MouseEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void MouseDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        PauseScreen.SetActive(true);
        MainMenu();
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        PauseScreen.SetActive(false);
        StartGame();
        Time.timeScale = 1;
    }

    public void Lost()
    {
        if (DoOnce == false)
        {
            LoseScreen.SetActive(true);
            MainMenu();
            MouseEnable();
            audioSource.PlayOneShot(LoseSFX);
            DoOnce = true;
        }
    }

    public void Won()
    {
        if (DoOnce == false)
        {
            WinScreen.SetActive(true);
            MainMenu();
            MouseEnable();
            audioSource.PlayOneShot(WinSFX);
            DoOnce = true;
        }
    }
}
