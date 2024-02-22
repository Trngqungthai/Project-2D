using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies;
    public float spawnRadius;

    public float moveSpeedMin;
    public float moveSpeedMax;

    public LayerMask obstacleLayer;

    private bool spawningEnemies = false;
    private int currentEnemyCount = 0;
    private void Start()
    {
        SpawnEnemies();         
    }
    private void Update()
    {
        StartCoroutine(CheckEnemyStatus());
    }
    private void SpawnEnemies()
    {
        spawningEnemies = true;
        currentEnemyCount = 0;

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 randomPosition = GetRandomPositionInSpawnArea();
            GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            enemy.name = "Enemy(" + (currentEnemyCount++) + ")";

            // Tạo một script EnemyMovement riêng cho mỗi enemy clone
            EnemyMovement enemyMovement = enemy.AddComponent<EnemyMovement>();
            enemyMovement.moveSpeed = Random.Range(moveSpeedMin, moveSpeedMax);
            enemyMovement.movePoint = GetRandomMovePoint(i);
            enemyMovement.obstacleLayer = obstacleLayer;
        }
    }

    private IEnumerator CheckEnemyStatus()
    {
        while (spawningEnemies)
        {
            yield return null;

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length == 0)
            {
                spawningEnemies = false;
                StartCoroutine(RespawnEnemies(10f));                
            }
        }
    }

    private IEnumerator RespawnEnemies(float delay)
    {
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < (numberOfEnemies/2); i++)
        {
            Vector2 randomPosition = GetRandomPositionInSpawnArea();
            GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            enemy.name = "Enemy(" + (currentEnemyCount++) + ")";

            // Tạo một script EnemyMovement riêng cho mỗi enemy clone
            EnemyMovement enemyMovement = enemy.AddComponent<EnemyMovement>();
            enemyMovement.moveSpeed = Random.Range(moveSpeedMin, moveSpeedMax);
            enemyMovement.movePoint = GetRandomMovePoint(i);
            enemyMovement.obstacleLayer = obstacleLayer;
        }
    }

    private Vector2 GetRandomPositionInSpawnArea()
    {
        Vector2 spawnCenter = transform.position;
        Vector2 randomPosition = spawnCenter + Random.insideUnitCircle * spawnRadius;
        return randomPosition;
    }

    private Transform GetRandomMovePoint(int number)
    {
        GameObject movePointObject = new GameObject("MovePoint(" + number + ")");
        movePointObject.transform.SetParent(transform);
        movePointObject.transform.position = GetRandomPositionInSpawnArea();
        return movePointObject.transform;
    }
}