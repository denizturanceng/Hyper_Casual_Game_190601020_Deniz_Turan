using UnityEngine;
using System.Collections.Generic;

public class CollectibleSpawner : MonoBehaviour
{


    [Header("Object")]
    [SerializeField] public GameObject prefab;

    [Header("Spawn Configuration")]
    [SerializeField] public float spawnInterval = 2f;
    [SerializeField] public Vector3 spawnArea = new Vector3(30, 0, 20);



    public float minDistanceBetweenPrefabs = 10f;
    public List<GameObject> prefabList;

    private float timeSinceLastSpawn;

    void Start()
    {
        prefabList = new List<GameObject>();
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            Vector3 spawnPosition = GenerateRandomSpawnPosition();
            if (spawnPosition != Vector3.zero)
            {
                GameObject newPrefab = Instantiate(prefab, spawnPosition, transform.rotation);
                prefabList.Add(newPrefab);
                timeSinceLastSpawn = 0f;
            }
        }

    }


    Vector3 GenerateRandomSpawnPosition()
    {
        Vector3 randomPosition = transform.position + new Vector3(Random.Range(-spawnArea.x / 2, spawnArea.x / 2), Random.Range(-spawnArea.y / 2, spawnArea.y / 2), Random.Range(-spawnArea.z / 2, spawnArea.z / 2));
        if (prefabList.Count > 0)
        {
            foreach (GameObject prefab in prefabList)
            {
                if (Vector3.Distance(randomPosition, prefab.transform.position) < minDistanceBetweenPrefabs)
                {
                    return Vector3.zero;
                }
            }
        }
        return randomPosition;
    }
}