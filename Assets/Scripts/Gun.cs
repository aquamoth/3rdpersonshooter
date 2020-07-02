using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField, Range(0.1f, 1.5f)] private float fireRate = 1f;
    [SerializeField, Range(1, 10)] private int damage = 1;
    [SerializeField] private ParticleSystem muzzleParticle = null;
    [SerializeField] private AudioSource gunFireSource = null;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();
            }
        }
    }

    private void FireGun()
    {

        muzzleParticle.Play();
        gunFireSource.Play();

        var ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);

        if (Physics.Raycast(ray, out RaycastHit hitinfo, 100f))
        {
            var health = hitinfo.collider.GetComponent<Health>();
            if (health != null)
                health.TakeDamage(damage);
        }

    }
}
