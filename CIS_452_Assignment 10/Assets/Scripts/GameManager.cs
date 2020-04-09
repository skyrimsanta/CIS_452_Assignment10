using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
/*
    * (Levi Schoof)
    * (GameManager.CS)
    * (Assignment 10)
    * (Handles the foundation of the Gameplay)
*/
public class GameManager : MonoBehaviour
{
    BulletSpawner bulletSpawner;
    CoinSpawner coinSpawner;

    public TextMeshProUGUI goldText;
    private int currentGold;

    public TextMeshProUGUI timerText;
    private float currentTime;
    public float gameLength = 30;

    public GameObject instructionsPanel;
    public GameObject endPanel;
    public TextMeshProUGUI endText;
    public TextMeshProUGUI resultsText;
    // Start is called before the first frame update
    void Start()
    {
        endPanel.SetActive(false);
        Time.timeScale = 0;
        bulletSpawner = FindObjectOfType<BulletSpawner>();
        coinSpawner = FindObjectOfType<CoinSpawner>();
    

        currentGold = 0;
        currentTime = 0;
        goldText.text = "Gold: " + currentGold;
    }

    private void Update()
    { 
        if(Time.timeScale == 0 && currentTime < gameLength && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            StartCoroutine(SpawnBullets());
            StartCoroutine(SpawnCoins());
            StartCoroutine(Timer());
        }

        else if(Time.timeScale == 0 && currentTime >= gameLength && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        else if(currentTime >= gameLength)
        {
            instructionsPanel.SetActive(false);
            Time.timeScale = 0;
            endPanel.SetActive(true);
            endText.text = "You Collected: " + currentGold + " Gold <br>Your Goal was 20 Gold";

            if (currentGold >= 20)
            {
                resultsText.text = "Victory";
            }

            else
            {
                resultsText.text = "You Lost";
            }
        }
    }

    IEnumerator SpawnBullets()
    {
        while (true)
        {
            yield return new WaitForSeconds(.4f);
            bulletSpawner.SpawnItem();
        }
    }

    IEnumerator SpawnCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(.5f);
            coinSpawner.SpawnItem();
        }
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(.0001f);
            currentTime += Time.deltaTime;
            timerText.text = "Time Left: " + (gameLength - currentTime).ToString("F2");
        }
    }

    public void IncreaseGold(int goldChange)
    {
        currentGold += goldChange;
        goldText.text = "Gold: " + currentGold;
    }
}
