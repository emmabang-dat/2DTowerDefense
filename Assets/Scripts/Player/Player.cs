using
	System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _cooldown;

	void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SpinAttack(5, 10, 1);
        }
    }

    private void SpinAttack(float range, int damage, float cooldown)
    {
        if (Time.time < _cooldown) return;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> validEnemies = new List<GameObject>();
        if (!enemies.Any()) return;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < range)
            {
                validEnemies.Add(enemy);
            }
        }

        if (validEnemies.Any())
        {
            foreach (GameObject enemy in validEnemies)
            {
                enemy.GetComponent<Enemy>().ApplyDamage(damage);
            }

            _cooldown = Time.time + cooldown;
        }

    }
}
