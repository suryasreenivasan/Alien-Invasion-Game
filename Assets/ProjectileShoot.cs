using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireCooldown = 0.5f;
    private float nextFireTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            nextFireTime = Time.time + fireCooldown;
        }
    }
}
