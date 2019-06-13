using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    public static EnemyPooler current;
    [SerializeField] GameObject enemy;
    [SerializeField] int poolAmount = 32;

    private List<GameObject> pooledEnemies;


    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        pooledEnemies = new List<GameObject>();
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(enemy);
            obj.SetActive(false);
            pooledEnemies.Add(obj);
        }
    }

    public GameObject GetPooledEnemies()
    {
        for (int i = 0; i < pooledEnemies.Count; i++)
        {
            if (!pooledEnemies[i].activeInHierarchy)
            {
                return pooledEnemies[i];
            }
        }
        return null;
    }
}
