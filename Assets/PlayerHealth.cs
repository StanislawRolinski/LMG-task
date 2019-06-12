using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;

    public int Health { get => health; set => health = value; }


    void Update()
    {
        if (Health <= 0)
        {
            SceneController.current.CheckScore();
            gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        SceneController.current.SetLives();
    }
}
