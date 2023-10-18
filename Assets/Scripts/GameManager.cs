using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabEasyEnemy;
    public GameObject prefabMediumEnemy;

    public float spawnInterval = 5f;
    private float elapsedTime;

    public GameObject[] prefabs;

    private int minSpawn = 1;
    private int maxSpawn = 2;
    private int wave = 0;
    private int maxEnemyIdx = 1;

    void Start()
    {
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnInterval)
        {
            int numberOfEnemies = Random.Range(minSpawn, maxSpawn);
            for (int i = 0; i < numberOfEnemies; i++)
            {
                float randomX = Random.Range(-180, 180);
                int enemyIdx = Random.Range(0, maxEnemyIdx);
                Vector3 spawnPosition = new Vector3(randomX, 0f, 150);
                Spawn(prefabs[enemyIdx], spawnPosition);
            }
            elapsedTime = 0f;
            wave++;

            if (wave % 5 == 0)
            {
                maxSpawn++;
            }

            if (wave == 10)
            {
                maxEnemyIdx = 2;
            }
        }
    }

    void Spawn(GameObject prefab, Vector3 initialPosition)
    {
        Instantiate(prefab, initialPosition, prefab.transform.rotation);
    }
}
