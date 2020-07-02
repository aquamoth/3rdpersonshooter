using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private AggroDetection aggroDetection;
    private Health healthTarget;
    private float attackTimer;
    
    [SerializeField, Range(0.1f, 1f)] private float attackRate = 1.5f;
    [SerializeField, Range(1, 10)] private int maxDamage = 1;
    [SerializeField] private ParticleSystem muzzleParticle = null;
    [SerializeField] private AudioSource gunFireSource = null;

    private void Awake()
    {
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetection_OnAggro;
    }

    private void AggroDetection_OnAggro(Transform target)
    {
        var health = target.GetComponent<Health>();
        if (health != null)
        {
            healthTarget = health;
        }
    }

    private void Update()
    {
        if (healthTarget != null && healthTarget.gameObject.activeInHierarchy)
        {
            attackTimer += Time.deltaTime;

            if (CanAttack())
                Attack();
        }
    }

    private bool CanAttack() => attackTimer >= attackRate;

    private void Attack()
    {
        attackTimer = 0;
        FireGun();
    }

    private void FireGun()
    {
        muzzleParticle.Play();
        gunFireSource.Play();

        if (IsHit())
        {
            healthTarget.TakeDamage(maxDamage);
        }
    }

    private static bool IsHit()
    {
        return UnityEngine.Random.Range(0, 100) < 30;
    }
}
