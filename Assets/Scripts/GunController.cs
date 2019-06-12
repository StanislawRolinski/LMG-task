using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField] ShotController bullet;
    [SerializeField] float bulletSpeed = 10;

    [SerializeField] float shotDelay = .5f;
    private float timeSinceLastShoot;
    private Camera mainCamera;

    private bool isFiring;

    [SerializeField] Transform firePoint;

    public bool IsFiring { get => isFiring; set => isFiring = value; }
    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }
    void Update()
    {
        
        //Rotate with Mouse
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLenght;

        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            Vector3 pointToShot = cameraRay.GetPoint(rayLenght);
            transform.LookAt(new Vector3(pointToShot.x, transform.position.y, pointToShot.z));
        }
        if (Input.GetMouseButtonDown(0))
        {
            IsFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            IsFiring = false;
        }
        if (IsFiring)
        {
            timeSinceLastShoot -= Time.deltaTime;
            if(timeSinceLastShoot <= 0)
            {
                timeSinceLastShoot = shotDelay;
                ShotController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as ShotController;
                bullet.BulletSpeed = bulletSpeed;
            }
        }
        else
        {
            timeSinceLastShoot = 0;
        }
        
    }
}

