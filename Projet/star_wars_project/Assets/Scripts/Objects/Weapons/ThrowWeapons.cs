using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ThrowWeapons : MonoBehaviour
{
    [SerializeField] private Button throwWeaponButton;
    [SerializeField] private TMP_Text weaponNameInput;
    [SerializeField] private GameObject weaponSelectorCanvas;
    [SerializeField] private GameObject menuContainer;

    private ObjectStorage objectStorage;
    private PlayerPosition playerPosition;
    private GameObject weaponObject = null;

    void Start()
    {
        objectStorage = FindObjectOfType<ObjectStorage>();
        playerPosition = FindObjectOfType<PlayerPosition>();
        throwWeaponButton.onClick.AddListener(DropWeapon);
    }

    public void DropWeapon()
    {
        if(objectStorage != null)
        {
            Weapons weaponToRemove = null;

            foreach(Weapons weapon in objectStorage.weaponsInStorage)
            {
                if(weapon.weaponName == weaponNameInput.text)
                {
                    weaponToRemove = weapon;
                    weaponObject.SetActive(true);
                    weaponObject = GameObject.Find(weaponToRemove.weaponName);
                    break;
                }
            }

            if(weaponToRemove != null)
            {
                Vector3 weaponPos = playerPosition.PositionDroppedWeapon();
                Instantiate(weaponToRemove, weaponPos, Quaternion.identity);
                weaponObject.SetActive(false);
                objectStorage.weaponsInStorage.Remove(weaponToRemove);
                menuContainer.SetActive(false);
                weaponSelectorCanvas.SetActive(false);

                Debug.Log(weaponToRemove.weaponName + " a bien ete retire");
            }

        }
    }
}
