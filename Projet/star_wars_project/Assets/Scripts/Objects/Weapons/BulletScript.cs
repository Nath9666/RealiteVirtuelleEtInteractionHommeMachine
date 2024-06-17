using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float bulletLifeTime = 3;

    void Update()
    {
        Destroy(this.gameObject, bulletLifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }
}
