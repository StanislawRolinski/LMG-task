using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] int scorePoints = 3;

    private void Update()
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
        health = 3;
    }
}
