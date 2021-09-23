using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthDamage : MonoBehaviour
{
    public int health = 100;

    public void Death()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 2;
        }
    }
}
