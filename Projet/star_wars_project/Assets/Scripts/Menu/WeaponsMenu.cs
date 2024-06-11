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
        // Vérifier si objectStorage est null pour éviter les erreurs
        if (objectStorage != null)
        {
            foreach (GameObject obj in objectStorage.weaponsInStorage)
            {
                weaponNameInputOne.text = obj.name;
            }
        }
        else
        {
            Debug.LogError("ObjectStorage not found!");
        }
    }
}
