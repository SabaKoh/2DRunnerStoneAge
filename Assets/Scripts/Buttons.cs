using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject SettingsBtns;

    public void LevelsButton()
    {
        SceneManager.LoadScene("LevelsMenu");
    }
    public void ExitButton()
    {
        print("Quit");
        Application.Quit();
    }
    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void PlayLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void PlayLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void SettingsBtn()
    {
        SettingsBtns.SetActive(true);
        FindObjectOfType<GameManager>().Pause();
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Restart()
    {
        SettingsBtns.SetActive(false);
        FindObjectOfType<Movement>().StartPos();
        FindObjectOfType<GameManager>().Play();
    }
    public void Resume()
    {
        SettingsBtns.SetActive(false);
        FindObjectOfType<GameManager>().Resume();
    }

    public void NextLevel()
    {
        FindObjectOfType<GameManager>().LoadNextLevel();
    }
}
