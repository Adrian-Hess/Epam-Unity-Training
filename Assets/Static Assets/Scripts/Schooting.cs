using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Schooting : MonoBehaviour
{
    /*
    public Transform firePoint;
    public GameObject bulletPrefab;
    //public AudioClip shootClip;
    //AudioSource audioSource;
    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("F")) 
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
        rb.AddForce(firePoint.forward.normalized * bulletForce, ForceMode.Impulse);
    }*/
    public GameObject patron_Prefab;
    public int maxAmmo = 50;
    public AudioClip clip;
    public AudioClip[] clips_shooting, clips_recharge;

    private Camera camera;
    private bool stop;
    private AudioSource source;
    private int Ammo;
    private float fireTimer;

    public Text text;
    private void Start()
    {
        Ammo = maxAmmo;
        source = GetComponent<AudioSource>();
        camera = GetComponent<Camera>();
    }
    private void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if(fireTimer >= 0)
        {
            fireTimer -= Time.deltaTime;
        }
        Vector3 point = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
        Ray ray = camera.ScreenPointToRay(point);
        Debug.DrawRay(transform.position, Vector3.forward, Color.red);
        if (Input.GetMouseButtonDown(0))
        {

        }
        if (Input.GetMouseButtonUp(0) && Ammo > 0 && !stop && fireTimer < 0)
        {
            fireTimer = 0.1f;
            Ammo -= 1;
            text.text = Ammo.ToString();
            clip = clips_shooting[Random.Range(0, clips_shooting.Length)];
            StartCoroutine(playSound());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var enemyHealth = hit.transform.gameObject.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.Hit(2);
                }
                StartCoroutine(CreatePatron(hit.point, hit.normal));
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && !stop)
        {
            Ammo = maxAmmo;
            clip = clips_recharge[Random.Range(0, clips_recharge.Length)];
            StartCoroutine(playSound());
        }
    }

    IEnumerator CreatePatron(Vector3 pos, Vector3 hit)
    {
        GameObject sprite_patron = Instantiate(patron_Prefab, pos + hit * 0.1f, Quaternion.LookRotation(-hit));

        yield return new WaitForSeconds(1);
        Destroy(sprite_patron);
    }

    IEnumerator playSound()
    {
        stop = true;
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        stop = false;
    }
}
