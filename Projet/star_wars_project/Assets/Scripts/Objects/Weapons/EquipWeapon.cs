using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject weaponContainer;

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
        HoldWeaponPosition();
    }

    public void SelectWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RemoveWeaponHold();
            Debug.Log("Aucune arme équipee");
            weaponEquip = null;
        }
        else if (ObjectStorage.instance.weaponsInStorage.Count > 0 && Input.GetKeyDown(KeyCode.Alpha2))
        {
            RemoveWeaponHold();
            weaponEquip = ObjectStorage.instance.weaponsInStorage[0];
            Debug.Log("L'arme selectionne est : " + weaponEquip);
        }
        else if (ObjectStorage.instance.weaponsInStorage.Count > 1 && Input.GetKeyDown(KeyCode.Alpha3))
        {
            RemoveWeaponHold();
            weaponEquip = ObjectStorage.instance.weaponsInStorage[1];
            Debug.Log("L'arme selectionne est : " + weaponEquip);
        }
    } 

    public void HoldWeaponPosition()
    {
        if(weaponEquip != null)
        {
            weaponEquip.isHold = true;
            weaponEquip.transform.parent = player.transform;
            weaponEquip.transform.position = PlayerPosition.instance.PositionHoldWeapon(); // Utiliser la position de dépose définie par PlayerPosition
            weaponEquip.gameObject.SetActive(true);


        }
    }

    public void RemoveWeaponHold()
    {
        if (weaponEquip != null && weaponEquip.transform.parent == player.transform)
        {
            weaponEquip.transform.parent = null; // Retirer l'arme de son parent (le joueur)
            weaponEquip.transform.parent = weaponContainer.transform;
            weaponEquip.gameObject.SetActive(false); // Désactiver l'arme pour la rendre invisible ou inactive
            weaponEquip = null; // Réinitialiser la référence de l'arme équipée
        }
    }
}
