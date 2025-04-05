using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AimAndShoot : MonoBehaviour
{
    public GameObject arrow;              // Reference to the arrow (child of this object)
    public GameObject projectilePrefab;   // The projectile to shoot
    public float shootForce = 10f;
    public float angleFix = -45f;

    private Camera cam;
    private bool isAiming = false;

    void Start()
    {
        cam = Camera.main;
        arrow.SetActive(false); // Start hidden
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartAiming();
        }

        if (isAiming)
        {
            AimArrow();
        }

        if (Input.GetMouseButtonUp(0) && isAiming)
        {
            ShootProjectile();
            StopAiming();
        }
    }

    void StartAiming()
    {
        isAiming = true;
        arrow.SetActive(true);
        AimArrow(); // Immediately aim at the mouse when the arrow appears
    }

    void StopAiming()
    {
        isAiming = false;
        arrow.SetActive(false);
    }

    void AimArrow()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        arrow.transform.rotation = Quaternion.Euler(0, 0, angle+angleFix);
    }

    void ShootProjectile()
    {
        Vector3 spawnPos = arrow.transform.position;
        Quaternion rotation = arrow.transform.rotation;

        GameObject projectile = Instantiate(projectilePrefab, spawnPos, rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 direction = arrow.transform.right;
            rb.velocity = direction * shootForce;
        }

      
    }

    public void DestroyPotato()
    {
        Destroy(gameObject);
    }

  
}
