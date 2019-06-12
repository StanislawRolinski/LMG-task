using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10;
    private float liveTime = 5f;
    [SerializeField] int bulletDamage = 1;

    public float BulletSpeed { get => bulletSpeed; set => bulletSpeed = value; }

    private void Update()
    {
        liveTime -= Time.deltaTime;
       transform.Translate(Vector3.forward * BulletSpeed * Time.deltaTime);
        if(liveTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
