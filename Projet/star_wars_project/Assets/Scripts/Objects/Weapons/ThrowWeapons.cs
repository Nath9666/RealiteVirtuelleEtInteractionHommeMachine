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


    //si on ajoute de nouvelles armes il faudra les ajouter ici 
    [SerializeField] private GameObject sabreLazer;
    [SerializeField] private GameObject blaster;
    [SerializeField] private GameObject arbalete;

    private ObjectStorage objectStorage;
    private PlayerPosition playerPosition;
    private Dictionary<string, GameObject> weaponDictionary;


    void Start()
    {
        objectStorage = FindObjectOfType<ObjectStorage>();
        playerPosition = FindObjectOfType<PlayerPosition>();
        throwWeaponButton.onClick.AddListener(DropWeapon);
    
        weaponDictionary = new Dictionary<string, GameObject>
        {
            { "Sabre Laser", sabreLazer },
            { "Blaster", blaster },
            { "Arbalete", arbalete }
        };        
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
                    break;
                }
            }

            if(weaponToRemove != null)
            {
                Vector3 weaponPos = playerPosition.PositionDroppedWeapon();
                if (weaponDictionary.TryGetValue(weaponToRemove.weaponName, out GameObject weaponPrefab))
                {
                    weaponPrefab.transform.position = weaponPos;
                    weaponPrefab.SetActive(true);
                }




                objectStorage.weaponsInStorage.Remove(weaponToRemove);
                menuContainer.SetActive(false);
                weaponSelectorCanvas.SetActive(false);

                Debug.Log(weaponToRemove.weaponName + " a bien ete retire");
            }

        }
    }
}
