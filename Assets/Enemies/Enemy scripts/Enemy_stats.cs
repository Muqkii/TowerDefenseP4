using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Enemy_stats : MonoBehaviour
{
    public float damage;
    public float fireRate;
    public float health;
    public float speed;
    

    private void Update()
    {
        KillYourself();
    }

    private void KillYourself()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
