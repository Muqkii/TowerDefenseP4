using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class Enemy_stats : MonoBehaviour
{
    public float damage;
    public float health;
    public float manaPay;
    public float gap = 2;
    private string naam = "tree_01";

    private void Update()
    {
        KillYourself();
        Terrorism();
    }

    private void KillYourself()
    {
        if (health <= 0)
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<TowerPlacing>().manaPool += manaPay;
            Destroy(gameObject);
        }
    }

    public void Terrorism()
    {
        if(gameObject != null)
        {
            GameObject boom = GameObject.Find(naam);
            //naam = boom.name;
            if (Vector3.Distance(transform.position, boom.transform.position) < gap)
            {
                Debug.Log("IM AT MY END");
                boom.GetComponent<EndTower>().health -= damage;
                Destroy(gameObject);
                Debug.Log(boom.GetComponent<EndTower>().health);
            }
        }

    }
}
