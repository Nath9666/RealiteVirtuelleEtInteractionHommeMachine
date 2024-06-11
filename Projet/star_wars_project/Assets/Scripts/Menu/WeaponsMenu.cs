using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsMenu : MonoBehaviour
{
    [SerializeField] private Button weaponButton;
    [SerializeField] private GameObject weaponMenu;
    [SerializeField] private GameObject mainMenu;


    void Start()
    {
        weaponMenu.SetActive(false);
        weaponButton.onClick.AddListener(OpenWeaponMenu);
    }

    public void OpenWeaponMenu()
    {
        mainMenu.SetActive(false);
        weaponMenu.SetActive(!weaponMenu.activeSelf);
    }
}
