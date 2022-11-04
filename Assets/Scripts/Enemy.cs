using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int CurrentHealth;

    public float Speed;
    private Waypoints waypoints;

    private int waypointIndex;

    public void ApplyDamage(int damage)
    {
        if (damage >= CurrentHealth)
        {
            Die();
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

    private void Die()
    {
        CurrentHealth = 0;
        Destroy(gameObject);
    }

    void Start()
    {
        waypoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints.waypoints[waypointIndex].position, Speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints.waypoints[waypointIndex].position) < 0.1f)
        {
            if (waypointIndex < waypoints.waypoints.Length - 1)
            {
                waypointIndex++;
            }
            else
            {
                Die();
            }
        }
    }

    void FixedUpdate()
    {
        if (waypoints.waypoints[waypointIndex].position.x < transform.position.x)
            transform.localScale = new Vector3(-System.Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); //flip the enemys forward
        else transform.localScale = new Vector3(System.Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); //flip the enemys forward
    }
}