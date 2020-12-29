using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem HitParticles;
    [SerializeField] ParticleSystem DeathParticles;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(DeathParticles, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        hitPoints--;
        HitParticles.Play();
    }
}
