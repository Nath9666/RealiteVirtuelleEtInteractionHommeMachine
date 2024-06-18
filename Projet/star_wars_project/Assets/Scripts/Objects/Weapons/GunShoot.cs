using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 20;
    public float fireRate = 0.5f;
    public AudioClip shootSound;

    private float nextFireTime = 0f;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing from this game object. Please add an AudioSource component.");
        }
    }

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

        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
        else
        {
            if (shootSound == null)
            {
                Debug.LogError("shootSound is not assigned. Please assign an AudioClip.");
            }
            if (audioSource == null)
            {
                Debug.LogError("AudioSource component is missing. Please add an AudioSource component.");
            }
        }
   }


    void OnDrawGizmos()
    {
        if (bulletSpawn != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(bulletSpawn.position, bulletSpawn.forward * 2);
        }
    }
}
