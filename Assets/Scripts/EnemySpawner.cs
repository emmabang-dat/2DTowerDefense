using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyReference;
    [SerializeField] private Transform spawnerPos;
    private GameObject spawnedMonster;
    private int randomIndex;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            randomIndex = Random.Range(0, enemyReference.Length);

            spawnedMonster = Instantiate(enemyReference[randomIndex]);

            spawnedMonster.transform.position = spawnerPos.position;
            //spawnedMonster.GetComponent<Enemy>().Speed = Random.Range(2, 3);
        }
    }
}
