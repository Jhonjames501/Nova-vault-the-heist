using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject[] digitFragmentPrefabs;
    [SerializeField] private GameObject laserObstaclePrefab;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval = 2f;
    private float spawnTimer;
    private float[] lanes = { -2.5f, 0f, 2.5f };
    [SerializeField] private float spawnZPosition = 120f;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnLaneObjects();
            spawnTimer = 0f;
        }
    }

    void SpawnLaneObjects()
    {
        int randomLane = Random.Range(0, lanes.Length);
        Vector3 spawnPos = new Vector3(lanes[randomLane], 1f, spawnZPosition);

        // Alternar aleatoriamente entre generar un dígito o un láser
        if (Random.value > 0.4f && digitFragmentPrefabs.Length > 0)
        {
            int randomDigitIndex = Random.Range(0, digitFragmentPrefabs.Length);
            Instantiate(digitFragmentPrefabs[randomDigitIndex], spawnPos, Quaternion.identity);
        }
        else
        {
            Instantiate(laserObstaclePrefab, spawnPos, Quaternion.identity);
        }
    }
}
