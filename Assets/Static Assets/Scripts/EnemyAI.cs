using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float seeDistance = 5f;
    public float attackDistance = 2f;
    public float speed = 7f;
    private Transform target;

    //public Transform firePoint;
    //public GameObject bulletPrefab;
    //public AudioClip shootClip;
    //AudioSource audioSource;
    //public float bulletForce = 20f;

    public GameObject patron_Prefab;
    public int maxAmmo = 50;
    //public AudioClip clip;
    //public AudioClip[] clips_shooting, clips_recharge;

    //private Camera camera;
    private bool stop;
    //private AudioSource source;
    private int Ammo;
    private float fireTimer;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        Ammo = maxAmmo;
        //source = GetComponent<AudioSource>();
        //camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < seeDistance)
        {
            transform.LookAt(target.transform);
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            if (Vector3.Distance (transform.position, target.transform.position) <= attackDistance)
            {
                Shoot();
            }
            else
            {
                Debug.Log("Waiting for a target...");
            }
        }
    }

    void Shoot()
    {
        if (fireTimer >= 0)
        {
            fireTimer -= Time.deltaTime;
        }

        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, Vector3.forward, Color.red);

        if (Ammo > 0 && !stop && fireTimer < 0)
        {
            fireTimer = 0.1f;
            Ammo -= 1;
            //clip = clips_shooting[Random.Range(0, clips_shooting.Length)];
            //StartCoroutine(playSound());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var playerHealth = hit.transform.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.Hit(2);
                }
                StartCoroutine(CreatePatron(hit.point, hit.normal));
            }
        }
    }

    IEnumerator CreatePatron(Vector3 pos, Vector3 hit)
    {
        GameObject sprite_patron = Instantiate(patron_Prefab, pos + hit * 0.1f, Quaternion.LookRotation(-hit));

        yield return new WaitForSeconds(1);
        Destroy(sprite_patron);
    }
    /*
    IEnumerator playSound()
    {
        stop = true;
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        stop = false;
    }*/
}
