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
            Debug.Log(weaponNameInput.text);
            foreach(Weapons weapon in objectStorage.weaponsInStorage)
            {
                if(weapon.weaponName == weaponNameInput.text)
                {
                    weaponToRemove = weapon;
                    Debug.Log(weaponToRemove.weaponName);
                    break;
                }
            }

            if(weaponToRemove != null)
            {
                objectStorage.weaponsInStorage.Remove(weaponToRemove);
                menuContainer.SetActive(false);
                weaponSelectorCanvas.SetActive(false);

                Vector3 playerPos = playerPosition.GetPlayerPosition();
                Debug.Log(playerPos);

                Debug.Log(weaponToRemove.weaponName + " a bien ete retire");
            }

        }
    }
}
