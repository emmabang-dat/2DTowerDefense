using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int Money; 
    public int startMoney = 400;

    public int Lives;
    public int startLives = 20;
    private LivesUI livesUI;

    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        livesUI = GameObject.FindGameObjectWithTag("HealthControllerUi").GetComponent<LivesUI>();
    }

    // Update is called once per frame
    void Update()
    {
        livesUI.lives = Lives;
    }
}
