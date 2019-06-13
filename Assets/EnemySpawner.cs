using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnSpeed = 4;
    private float timeSinceLastSpawn = 0;

    [SerializeField] float timeToEncreaseDifficulty = 10;
    private float timeSinceLastDifficultyEncrease = 0;

    [SerializeField] List<Transform> spawnPositions;


    private void Start()
    {
        SpawnEnemy();
    }

    private void Update()
    {
        if (timeSinceLastSpawn >= spawnSpeed)
        {
            timeSinceLastSpawn = 0;
           
                SpawnEnemy();
        }
        if(timeSinceLastDifficultyEncrease >= timeToEncreaseDifficulty)
        {
            if(spawnSpeed <= .5f)
            {
                spawnSpeed = .5f;
            }
            else
            {
                timeSinceLastDifficultyEncrease = 0;
                spawnSpeed -= 0.5f;
            }
        }
        timeSinceLastSpawn += Time.deltaTime;
        timeSinceLastDifficultyEncrease += Time.deltaTime;
    }

    private void SpawnEnemy()
    {
        int randomLocation = Random.Range(0, spawnPositions.Count);

        GameObject obj = EnemyPooler.current.GetPooledEnemies();
        if (obj != null)
        {
            obj.transform.position = spawnPositions[randomLocation].position;
            obj.transform.rotation = Quaternion.identity;
            obj.SetActive(true);
        }
    }
}
