﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;

    // Update is called once per frame
    void Update()
    {
        if(targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        } else
        {
            Shoot(false);
        }
        
    }

    private void FireAtEnemy()
    {
        var distance = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distance <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        print("shooting");
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
