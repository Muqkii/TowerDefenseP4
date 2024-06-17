using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTower : MonoBehaviour
{
    public float health = 100;

    void Start()
    {
        
    }

    void Update()
    {
        /*if (health < 0)
        {
            Debug.Log("Die");
        }*/
    }
    /*private void OnTriggerEnter(Collider collision)
    {

        Debug.Log("Ouch by " + collision.gameObject.name);
        if (CompareTag("Enemy"))
        {
            float damage = collision.gameObject.GetComponent<Enemy_stats>().damage;
            health -= damage;
            Destroy(collision.gameObject);
            Debug.Log(health);
        }
        
    }*/

}
