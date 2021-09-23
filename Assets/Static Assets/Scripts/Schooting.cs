using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    //public AudioClip shootClip;
    //AudioSource audioSource;
    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            Shoot();
            Debug.Log("Shoot!");
            //audioSource.PlayOneShot(shootClip);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);
    }
}
