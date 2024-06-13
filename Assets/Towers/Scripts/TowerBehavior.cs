using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    public float rangeValue;
    public float fireRate;
    public float hitDelay;
    public float damage;
    public float aoeSize;
    public bool hitAir;
    public bool hitGround;

    public Enemy_stats enemyStats;

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
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestEnemy = hitCollider.gameObject;
                        closestEnemyPosition = hitCollider.transform.position;
                    }
                }
            } 
            else if (hitAir == true)
            {
                if (hitCollider.CompareTag("Air"))
                {
                    float distance = Vector3.Distance(transform.position, hitCollider.transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestEnemy = hitCollider.gameObject;
                        closestEnemyPosition = hitCollider.transform.position;
                    }
                }
            }
        }
        
        if (closestEnemy != null && ableToShoot == true)
        {
            AttackCycle();
        }
    }
    public void AttackCycle()
    {
        ableToShoot = false;

        Invoke(nameof(EnemyDamage), hitDelay);
        Invoke(nameof(ResetCycle), fireRate);
    }
    private void ResetCycle()
    {
        ableToShoot = true;
    }
    private void EnemyDamage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(closestEnemyPosition, aoeSize);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                enemyStats.health = enemyStats.health - damage;
            }
        }
    }
}
