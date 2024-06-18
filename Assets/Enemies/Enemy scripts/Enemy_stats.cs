using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class Enemy_stats : MonoBehaviour
{
    public float damage;
    public float health;
    public float gap = 2;

    private GameObject boom;

    private void Start()
    {
        boom = GameObject.Find("tree_01");
    }

    private void Update()
    {
        KillYourself();
        Terrorism();
    }

    private void KillYourself()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Terrorism()
    {
            if (Vector3.Distance(transform.position, boom.transform.position) < gap)
            {
                Debug.Log("IM AT MY END");
                boom.GetComponent<EndTower>().health -= damage;
                Destroy(gameObject);
                Debug.Log(boom.GetComponent<EndTower>().health);
            }
        

    }
}
