using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10;

    public float BulletSpeed { get => bulletSpeed; set => bulletSpeed = value; }

    private void Update()
    {
       transform.Translate(Vector3.forward * BulletSpeed * Time.deltaTime);
    }
}
