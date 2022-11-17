using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 2f;

    public Rigidbody2D mybody;
    public Animator myAnimator;
    public SpriteRenderer myRenderer;

    private Vector2 movement;

    private float secSinceAbilityLastUsed;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x < 0) myRenderer.flipX = true;
        else myRenderer.flipX = false;

        myAnimator.SetFloat("Horizontal", movement.x);
        myAnimator.SetFloat("Vertical", movement.y);
        myAnimator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetButtonDown("Jump"))
        {
            SpinAttack(5, 10, 1);
            Debug.Log("space was pressed");
        }
    }

    void FixedUpdate()
    {
        mybody.MovePosition(mybody.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Enemy"))
        //{
        //    Enemy _enemy = collision.gameObject.GetComponent<Enemy>();
        //    _enemy.ApplyDamage(10);
        //}
    }

    private void SpinAttack(float range, int damage, float cooldown)
    {
        if (Time.time < secSinceAbilityLastUsed) return;

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

            secSinceAbilityLastUsed = Time.time + cooldown;
        }

    }
}
