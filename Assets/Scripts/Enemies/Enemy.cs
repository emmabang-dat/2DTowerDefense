using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int CurrentHealth { get; private set; }
    public int MaxHealth;

    public bool movementFlipped;

    public float Speed;
    private Waypoints waypoints;

    private int waypointIndex;

    public int moneyValue;
    public int scoreValue;

    private PlayerStats playerStats;
    private ScoreUI scoreUI;

    public void ApplyDamage(int damage)
    {
        
        if (damage >= CurrentHealth)
        {
            playerStats.Money += moneyValue;
            playerStats.Score += scoreValue;
            Destroy(gameObject);
        }
        else
        {
            CurrentHealth -= damage;
        }
    }

    public void ApplySpeed(float speed)
    {
        Mathf.Clamp(Speed = Speed + speed, 0.5f, 2f);
    }


    void Start()
    {
        CurrentHealth = MaxHealth;
        waypoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        playerStats = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
        scoreUI = GameObject.FindGameObjectWithTag("ScoreControllerUi").GetComponent<ScoreUI>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints.waypoints[waypointIndex].position, Speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints.waypoints[waypointIndex].position) < 0.1f)
        {
            if (waypointIndex < waypoints.waypoints.Length - 1)
            {
                waypointIndex++;
            }
            else
            {
                Destroy(gameObject);
                PlayerStats playerStats = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
                playerStats.Lives -= 1; 
            }

        }
    }

    void FixedUpdate()
    {
        if (waypoints.waypoints[waypointIndex].position.x < transform.position.x)
        {
            movementFlipped = true;
        }
        else
        {
            movementFlipped = false;
        }

        if (movementFlipped)
        {
            transform.localScale = new Vector3(-System.Math.Abs(transform.localScale.x), transform.localScale.y,
                transform.localScale.z); //flip the enemys forward
        }
        else
        {
            transform.localScale = new Vector3(System.Math.Abs(transform.localScale.x), transform.localScale.y,
                transform.localScale.z); //flip the enemys forward
        }

    }
}
