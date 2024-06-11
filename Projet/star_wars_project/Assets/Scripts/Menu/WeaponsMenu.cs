using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponsMenu : MonoBehaviour
{
    [SerializeField] private Button weaponButton;
    [SerializeField] private GameObject weaponMenu;
    [SerializeField] private GameObject mainMenu;

    [SerializeField] private TMP_Text weaponNameInputOne;
    [SerializeField] private TMP_Text weaponNameInputTwo;

    private ObjectStorage objectStorage;

    void Start()
    {
        objectStorage = FindObjectOfType<ObjectStorage>();

        weaponMenu.SetActive(false);
        weaponButton.onClick.AddListener(OpenWeaponMenu);
        weaponButton.onClick.AddListener(DisplayWeaponsInformation);
    }

    public void OpenWeaponMenu()
    {
        mainMenu.SetActive(false);
        weaponMenu.SetActive(!weaponMenu.activeSelf);
    }

    private void DisplayWeaponsInformation()
    {
        if (objectStorage != null)
        {
            // Effacer le texte avant d'afficher les nouvelles informations
            weaponNameInputOne.text = "";
            weaponNameInputTwo.text = "";

            int count = 0;
            foreach (Weapons obj in objectStorage.weaponsInStorage)
            {
                if (count == 0)
                {
                    weaponNameInputOne.text = obj.weaponName;
                }
                else if (count == 1)
                {
                    weaponNameInputTwo.text = obj.weaponName;
                }
                count++;
            }
        }
        else
        {
            Debug.LogError("ObjectStorage not found!");
        }
    }
}
