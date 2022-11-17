using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableLandHandler : MonoBehaviour
{
    private PlayerStats playerStats;
    public GameObject tower;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && playerStats.Money >= 200)
        {
            playerStats.Money -= 200;
            PlaceTower();
        }
    }

    private void PlaceTower()
    {
        Instantiate(tower, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
