using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonsterMovement
{
    public int CurrentHealth { get; private set; }

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

    private void Die()
    {
        CurrentHealth = 0;
        Destroy(gameObject);
    }

    void Start()
    {
        //inhertiance doesnt work on base methods like Start() and Update()
    }
}
