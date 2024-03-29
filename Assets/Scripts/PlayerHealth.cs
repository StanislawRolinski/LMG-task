﻿using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] float immuneTime = 1f;
    private float timeSinceLastImmune = 0;



    public int Health { get => health; set => health = value; }


    private void Update()
    {
        if (Health <= 0)
        {
            SceneController.current.CheckScore();
            Time.timeScale = 0;
            SceneController.current.SetActiveEndGamePanel();
            gameObject.SetActive(false);
        }
        timeSinceLastImmune += Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        if(timeSinceLastImmune > immuneTime)
        {
            timeSinceLastImmune = 0;
            Health -= damage;
            SceneController.current.SetLives();
        }

    }
}
