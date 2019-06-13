using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damageDealt = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageDealt);
        }
    }
}
