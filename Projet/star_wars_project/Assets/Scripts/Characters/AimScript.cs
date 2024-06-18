using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform aimPoint;

    public static AimScript instance;

    private Dictionary<string, Vector3> aimPointPositions;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Il y a plus d'une instance AimScript dans la scene");
            return;
        }
        instance = this;

        // Initialize the aimPoint positions dictionary
        aimPointPositions = new Dictionary<string, Vector3>
        {
            { "Blaster", new Vector3(0, 0, 2) },
            { "Sabre Laser", new Vector3(0, 1, 1) },
            // Add other weapons and their aimPoint positions here
        };
    }

    void Update()
    {
        AimWeaponEquip();
    }

    public void AimWeaponEquip()
    {
        if (EquipWeapon.instance.weaponEquip != null)
        {
            aimPoint.transform.parent = null;
            aimPoint.transform.parent = EquipWeapon.instance.weaponEquip.transform;

            string weaponName = EquipWeapon.instance.weaponEquip.weaponName;
            if (aimPointPositions.ContainsKey(weaponName))
            {
                aimPoint.transform.localPosition = aimPointPositions[weaponName];
                aimPoint.transform.localRotation = Quaternion.identity;
            }
            else
            {
                Debug.Log("Weapon not recognized, using default aimPoint position.");
            }
        }
        else
        {
            // Handle the case where no weapon is equipped
            aimPoint.transform.parent = player.transform;
            aimPoint.transform.localPosition = new Vector3(0, 1, 2); // Example position for player without weapon
            aimPoint.transform.localRotation = Quaternion.identity;
        }
    }
}
