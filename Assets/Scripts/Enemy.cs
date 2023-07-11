using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    
    void Start()
    {
        ShootFunctionRepeat();
    }
    void ShootFunctionRepeat()
    {
        InvokeRepeating("Shoot", 0.0f, 2.0f);
    }
    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = -bulletSpawnPoint.right * bulletSpeed;
    }
}
