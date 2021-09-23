using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthDamage : MonoBehaviour
{
    public int health = 10;
   
    public void Death()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health -= 2;
        }
    }
}
