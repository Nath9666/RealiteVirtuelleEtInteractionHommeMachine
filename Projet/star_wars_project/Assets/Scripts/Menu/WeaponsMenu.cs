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

    [SerializeField] private Image weaponImageOne;
    [SerializeField] private Image weaponImageTwo;

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
            weaponImageOne.sprite = null;
            weaponImageTwo.sprite = null;

            int count = 0;
            foreach (Weapons obj in objectStorage.weaponsInStorage)
            {
                if (count == 0)
                {
                    weaponNameInputOne.text = obj.weaponName;
                    weaponImageOne.sprite = obj.weaponImage;
                }
                else if (count == 1)
                {
                    weaponNameInputTwo.text = obj.weaponName;
                    weaponImageTwo.sprite = obj.weaponImage;

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
