using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] public float targetLife = 2f; 
    [SerializeField] public GameObject target; 
    [SerializeField] public bool isHit = false;
    [SerializeField] public bool noMoreTargetLife = false;
    [SerializeField] public float gamePoint = 0;
    [SerializeField] public bool isStart = false;

    public static Target instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Target dans la scene");
            return;
        }
        instance = this;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(isStart)
        {
            if(collision.gameObject.CompareTag("Bullet"))
            {
                isStart = true;
                gamePoint += 1;
                isHit = true;
            }
        }

    }

    void Update()
    {
        if(isStart)
        {
            if(targetLife > 0)
            {
                targetLife -= Time.deltaTime;
            }    
            else
            {
                targetLife = 0;
                noMoreTargetLife = true;
            } 
        } 
    }
}
