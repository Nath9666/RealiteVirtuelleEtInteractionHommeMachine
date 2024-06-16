using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 20;
    public float fireRate = 0.5f;
    // public AudioClip shootSound;

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFireTime && EquipWeapon.instance.weaponEquip != null && EquipWeapon.instance.weaponEquip.weaponType == "Arme a feu")
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;

        // Jouer le son de tir
        // if (shootSound != null && audioSource != null)
        // {
        //     audioSource.PlayOneShot(shootSound);
        // }

        // Debug Log for checking direction
        Debug.Log("Bullet direction: " + bulletSpawn.forward);
    }

    // Draw a ray in the Scene view to visualize bullet direction
    void OnDrawGizmos()
    {
        if (bulletSpawn != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(bulletSpawn.position, bulletSpawn.forward * 2);
        }
    }
}
