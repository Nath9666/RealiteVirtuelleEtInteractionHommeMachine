using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectStorage : MonoBehaviour
{
    public List<Weapons> weaponsInStorage = new List<Weapons>();
    [SerializeField] private GameObject menuContainer;
    [SerializeField] private GameObject weaponsMenu;

    [SerializeField] private TMP_Text weaponNameInputOne;
    [SerializeField] private TMP_Text weaponNameInputTwo;
    [SerializeField] private TMP_Text weaponNameInputThree;

    [SerializeField] private Image weaponImageOne;
    [SerializeField] private Image weaponImageTwo;
    [SerializeField] private Image weaponImageThree;

    private PlayerController playerController;
    public bool isWeaponSelectorOpen = false;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void AddObjectToStorage(Weapons objet)
    {
        if (weaponsInStorage.Count < 2)
        {
            weaponsInStorage.Add(objet);
        }
        else
        {
            playerController.isCameraLock = true;
            isWeaponSelectorOpen = true;

            weaponsInStorage.Add(objet);
            menuContainer.SetActive(true);
            weaponsMenu.SetActive(true);

            weaponNameInputOne.text = "";
            weaponNameInputTwo.text = "";
            weaponNameInputThree.text = "";
            weaponImageOne.sprite = null;
            weaponImageTwo.sprite = null;
            weaponImageThree.sprite = null;

            if (weaponsInStorage.Count > 0)
            {
                weaponNameInputOne.text = weaponsInStorage[0].weaponName;
                weaponImageOne.sprite = weaponsInStorage[0].weaponImage;
            }
            if (weaponsInStorage.Count > 1)
            {
                weaponNameInputTwo.text = weaponsInStorage[1].weaponName;
                weaponImageTwo.sprite = weaponsInStorage[1].weaponImage;
            }
            if (weaponsInStorage.Count > 2)
            {
                weaponNameInputThree.text = weaponsInStorage[2].weaponName;
                weaponImageThree.sprite = weaponsInStorage[2].weaponImage;
            }

            Debug.Log("Le sac est plein");
        }
    }
}
