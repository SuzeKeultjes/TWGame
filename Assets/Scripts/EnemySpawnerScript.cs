using System.Collections;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemyPrefab; // Het prefab van de vijand die gespawned moet worden
    public GameObject bigEnemyPrefab; // Het prefab van de vijand die gespawned moet worden
    public float spawnRate; // De frequentie waarmee vijanden gespawned worden
    float timer;

    void Awake()
    {
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (spawnRate <= timer)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    public void SpawnEnemy()
    {
      Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
      Instantiate(bigEnemyPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }
}