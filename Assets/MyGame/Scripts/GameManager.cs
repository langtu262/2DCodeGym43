using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int sumCoin;
    // Start is called before the first frame update
    void Start()
    {
        sumCoin = PlayerPrefs.GetInt("Coin", 10);
        AudioManager.Instance.BackGroundMusic();
        EventManagerGame.onHealth.AddListener(UpdateHealth);
        EventManagerGame.onCoin.AddListener(UpdateCoin);
        Invoke("loadCoin", 0.5f); // neu goi lien thi UIManager khong nhan kip


    }
    void UpdateHealth(int health)
    {
        if (health < 0)
        {
            FinishGame();
        }
    }
    void UpdateCoin(int coin)
    {
        sumCoin += coin;
        PlayerPrefs.SetInt("Coin", sumCoin);
        EventManagerGame.onSumCoin?.Invoke(sumCoin);
    }
    void loadCoin()
    {
        EventManagerGame.onSumCoin?.Invoke(sumCoin);
    }


    // Update is called once per frame

    void FinishGame()
    {
      //  SceneManager.LoadScene("GameOver");
    }
    private void OnDisable()
    {
        EventManagerGame.onHealth.RemoveListener(UpdateHealth);
        EventManagerGame.onCoin.RemoveListener(UpdateCoin);
    }
}