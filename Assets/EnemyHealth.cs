using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] int scorePoints = 3;


    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            SceneController.current.AddToScore(scorePoints);
            gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    private void OnEnable()
    {
        health = 1;
    }
}
