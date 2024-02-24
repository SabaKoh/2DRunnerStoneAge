using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Movement player;

    [SerializeField] private float livesCount = 3;
    [SerializeField] private GameObject life2Empty;
    [SerializeField] private GameObject life3Empty;
    [SerializeField] private GameObject life2;
    [SerializeField] private GameObject life3;

    [SerializeField] private GameObject[] eggs;

    [SerializeField] private TextMeshProUGUI CoinsText;
    [SerializeField] private int CoinCount;

    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject fade;

    public void Play()
    {
        print("play");
        livesCount = 3;
        CoinCount = 0;
        CoinsText.text = CoinCount.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        fade.SetActive(false);
        for (int i = 0; i < eggs.Length; i++)
        {
            eggs[i].gameObject.SetActive(true);
        }

        Time.timeScale = 1f;
        player.enabled = true;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);
        fade.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        CoinCount++;
        CoinsText.text = CoinCount.ToString();
    }
    
    public void DecreaseLives()
    {
        livesCount--;
    }

    public void Update()
    {
        if (livesCount == 3)
        {
            life2Empty.gameObject.SetActive(false);
            life3Empty.gameObject.SetActive(false);
            life2.gameObject.SetActive(true);
            life3.gameObject.SetActive(true);
        }
        if (livesCount == 2)
        {
            life3.gameObject.SetActive(false);
            life3Empty.gameObject.SetActive(true);
        }
        if (livesCount == 1)
        {
            life2.gameObject.SetActive(false);
            life2Empty.gameObject.SetActive(true);
        }
        if (livesCount == 0)
        {
            GameOver();
        }
    }
}
