using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    public float rangeValue;
    public float fireRate;
    public float hitDelay;
    public float towerDamage;
    public float aoeSize;
    public float manaCost;
    public bool hitAir;
    public bool hitGround;

    private GameObject gevondenEnemy;
    private float enemyHealth;

    private bool ableToShoot = true;

    private GameObject closestEnemy;
    private Vector3 closestEnemyPosition;

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, rangeValue);
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitGround == true)
            {
                if (hitCollider.CompareTag("Enemy"))
                {
                    float distance = Vector3.Distance(transform.position, hitCollider.transform.position);
                    gevondenEnemy = hitCollider.gameObject;
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestEnemy = hitCollider.gameObject;
                        closestEnemyPosition = hitCollider.transform.position;
                        Debug.Log("enemy is gevonden q");
                        if (ableToShoot == true)
                        {
                            Debug.Log("attack cycle word aangeroepen q");
                            AttackCycle();
                        }
                    }
                }
            } 
            else if (hitAir == true)
            {
                if (hitCollider.CompareTag("Air"))
                {
                    float distance = Vector3.Distance(transform.position, hitCollider.transform.position);
                    gevondenEnemy = hitCollider.gameObject;
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestEnemy = hitCollider.gameObject;
                        closestEnemyPosition = hitCollider.transform.position;
                        if (ableToShoot == true)
                        {
                            AttackCycle();
                            Debug.Log("attack cycle word aangeroepen q");
                        }
                    }
                }
            }
        }
    }
    public void AttackCycle()
    {
        ableToShoot = false;

        Invoke(nameof(EnemyDamage), hitDelay);
        Invoke(nameof(ResetCycle), fireRate);
        Debug.Log("attack cycle word afgemaakt q");
    }
    private void ResetCycle()
    {
        ableToShoot = true;
        Debug.Log("cycle word gereset q");
    }
    private void EnemyDamage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(closestEnemyPosition, aoeSize);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                gevondenEnemy.GetComponent<Enemy_stats>().health -= towerDamage;
            }
            if (hitCollider.CompareTag("Air"))
            {
                gevondenEnemy.GetComponent<Enemy_stats>().health -= towerDamage;
            }
        }
    }
}
