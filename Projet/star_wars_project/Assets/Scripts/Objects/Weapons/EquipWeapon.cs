using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{
    public static EquipWeapon instance;
    public Weapons weaponEquip;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Il y a plus d'une instance de PlayerController dans la scene");
            return;
        }
        instance = this;
    }
    
    void Update()
    {
        SelectWeapon();
    }
    public void SelectWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Aucune arme équipee");
        }
        else if (ObjectStorage.instance.weaponsInStorage.Count > 0 && Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponEquip = ObjectStorage.instance.weaponsInStorage[0];
            // Debug.Log("L'arme selectionne est : " + weaponEquip);
        }
        else if (ObjectStorage.instance.weaponsInStorage.Count > 1 && Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponEquip = ObjectStorage.instance.weaponsInStorage[1];
            // Debug.Log("L'arme selectionne est : " + weaponEquip);
        }
    } 
}
