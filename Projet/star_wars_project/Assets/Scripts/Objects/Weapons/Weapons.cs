using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapons : MonoBehaviour
{
    [SerializeField] public string weaponName;
    [SerializeField] public string weaponType;
    [SerializeField] public Sprite weaponImage;
    [SerializeField] public bool isHold = false;

    public static Weapons instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Weapons dans la scene");
            return;
        }
        instance = this;
    }

    
}
