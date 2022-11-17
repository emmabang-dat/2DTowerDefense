using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int Money;
    public int startMoney = 400;

    public int Lives;
    public int startLives = 20;

    public int Score;

    private LivesUI livesUI;
    private MoneyUI moneyUI;
    private ScoreUI scoreUI;

    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        livesUI = GameObject.FindGameObjectWithTag("HealthControllerUi").GetComponent<LivesUI>();
        moneyUI = GameObject.FindGameObjectWithTag("MoneyControllerUi").GetComponent<MoneyUI>();
        scoreUI = GameObject.FindGameObjectWithTag("ScoreControllerUi").GetComponent<ScoreUI>();
        scoreUI.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        moneyUI.money = Money;
        livesUI.lives = Lives;
        scoreUI.score = Score;
        if (Lives <= 0)
        {
            Time.timeScale = 0f;
        }
    }
}
