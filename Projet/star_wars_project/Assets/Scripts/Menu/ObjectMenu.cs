using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuContainer;
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject weaponsCanvas;

    private bool menuActive = false;
    private ObjectStorage objectStorage;
    private PlaneteMenu planeteMenu;

    void Start()
    {
        planeteMenu = FindAnyObjectByType<PlaneteMenu>();
        objectStorage = FindObjectOfType<ObjectStorage>();
        menuContainer.SetActive(false);
    }

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.E) && !objectStorage.isWeaponSelectorOpen && !planeteMenu.isPlanetSelectorOpen)
        {
            if (!menuActive)
            {
                OpenMainMenu();
            }
            else
            {
                CloseAllMenus();
            }
        }
    }

    void OpenMainMenu()
    {
        PlayerController.instance.isCameraLock = true;
        menuContainer.SetActive(true);
        menuCanvas.SetActive(true);
        weaponsCanvas.SetActive(false);
        menuActive = true;
    }

    void CloseAllMenus()
    {
        PlayerController.instance.isCameraLock = false;
        menuContainer.SetActive(false);
        menuCanvas.SetActive(false);
        weaponsCanvas.SetActive(false);
        menuActive = false;
    }
}
