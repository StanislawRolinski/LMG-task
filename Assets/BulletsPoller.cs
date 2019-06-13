using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPoller : MonoBehaviour
{
    public static BulletsPoller current;
    [SerializeField] GameObject bullet;
    [SerializeField] int poolAmount = 30;

    List<GameObject> pooledBullets;


    private void Awake()
    {
        current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pooledBullets = new List<GameObject>();
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(bullet);
            obj.SetActive(false);
            pooledBullets.Add(obj);
        }
    }

    public GameObject GetPooledEnemies()
    {
        for (int i = 0; i < pooledBullets.Count; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }
        return null;
    }
}
