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
    [SerializeField] private GameObject[] lives;

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
            lives[0].gameObject.SetActive(false); // life 2 empty
            lives[1].gameObject.SetActive(false); // life 3 empty
            lives[2].gameObject.SetActive(true);  // life 2
            lives[3].gameObject.SetActive(true);  // life 3
        }
        if (livesCount == 2)
        {
            lives[3].gameObject.SetActive(false);
            lives[1].gameObject.SetActive(true);
        }
        if (livesCount == 1)
        {
            lives[2].gameObject.SetActive(false);
            lives[0].gameObject.SetActive(true);
        }
        if (livesCount == 0)
        {
            GameOver();
        }
    }
}
