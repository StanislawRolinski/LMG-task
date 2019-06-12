using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnSpeed = 4;
    private float timeSinceLastSpawn = 0;

    [SerializeField] float timeToEncreaseDifficulty = 10;
    private float timeSinceLastDifficultyEncrease = 0;
    [SerializeField] List<Transform> spawnPositions;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastSpawn >= spawnSpeed)
        {
            timeSinceLastSpawn = 0;
           
                SpawnEnemy();
        }
        if(timeSinceLastDifficultyEncrease >= timeToEncreaseDifficulty)
        {
            timeSinceLastDifficultyEncrease = 0;
            spawnSpeed -= 0.5f;
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
