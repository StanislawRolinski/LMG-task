using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    public static EnemyPooler current;
    [SerializeField] GameObject enemy;
    [SerializeField] int poolAmount = 32;

    List<GameObject> pooledEnemies;


    private void Awake()
    {
        current = this;
    }
    // Start is called before the first frame update
    void Start()
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
