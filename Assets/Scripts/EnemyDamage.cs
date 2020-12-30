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

    public void KillEnemy()
    {
        var vfx = Instantiate(DeathParticles, transform.position, Quaternion.identity);
        var enemyVfx = GameObject.FindGameObjectWithTag("VFX List");
        vfx.transform.SetParent(enemyVfx.transform);
        vfx.Play();
        Destroy(gameObject, vfx.main.duration);
    }

    private void ProcessHit()
    {
        hitPoints--;
        HitParticles.Play();
    }
}
