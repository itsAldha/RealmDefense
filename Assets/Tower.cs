using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 20f;
    [SerializeField] ParticleSystem projectileParticle;

    Transform targetEnemy;
    void Update()
    {
        SetTargetEnemy();
        if(targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
            Shoot(false);
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) return;

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach(EnemyDamage testEnemy in sceneEnemies)
        {
            if (Vector3.Distance(testEnemy.transform.position, gameObject.transform.position) < Vector3.Distance(closestEnemy.position,gameObject.transform.position))
                closestEnemy = testEnemy.transform;
        }
        targetEnemy = closestEnemy;
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if(distanceToEnemy <= attackRange)
            Shoot(true);
        else
            Shoot(false);
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
