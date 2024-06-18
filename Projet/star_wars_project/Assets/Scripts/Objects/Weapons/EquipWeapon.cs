using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{
    [SerializeField] private GameObject weaponPosition;
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
            Debug.Log("Aucune arme équipée");
            weaponEquip = null;
        }
        else if (ObjectStorage.instance.weaponsInStorage.Count > 0 && Input.GetKeyDown(KeyCode.Alpha2))
        {
            RemoveWeaponHold();
            weaponEquip = ObjectStorage.instance.weaponsInStorage[0];
            Debug.Log("L'arme sélectionnée est : " + weaponEquip.weaponName);
        }
        else if (ObjectStorage.instance.weaponsInStorage.Count > 1 && Input.GetKeyDown(KeyCode.Alpha3))
        {
            RemoveWeaponHold();
            weaponEquip = ObjectStorage.instance.weaponsInStorage[1];
            Debug.Log("L'arme sélectionnée est : " + weaponEquip.weaponName);
        }
    }

    public void HoldWeaponPosition()
    {
        if (weaponEquip != null)
        {
            weaponEquip.isHold = true;
            weaponEquip.transform.parent = weaponPosition.transform;
            weaponEquip.transform.localPosition = WeaponSpecificPosition();
            weaponEquip.transform.localRotation = WeaponSpecificRotation();
            weaponEquip.gameObject.SetActive(true);
        }
    }

    public void RemoveWeaponHold()
    {
        if (weaponEquip != null && weaponEquip.transform.parent == weaponPosition.transform)
        {
            weaponEquip.transform.parent = null;
            weaponEquip.transform.parent = weaponContainer.transform;
            weaponEquip.gameObject.SetActive(false);
            weaponEquip = null;
        }
    }


    public Vector3 WeaponSpecificPosition()
    {
        switch(weaponEquip.weaponName)
        {
            case "Blaster":
                return Vector3.zero;
            case "Sabre Laser":
                return new Vector3(0.5f, -0.75f, 0.5f);
            default:
                return Vector3.zero;
        }
    }


    public Quaternion WeaponSpecificRotation()
    {
        switch(weaponEquip.weaponName)
        {
            case "Blaster":
                return Quaternion.Euler(-90, 180, 0);
            case "Sabre Laser":
                return Quaternion.Euler(-90, 0, 0);
            default:
                return Quaternion.identity;
        }
    }
}
