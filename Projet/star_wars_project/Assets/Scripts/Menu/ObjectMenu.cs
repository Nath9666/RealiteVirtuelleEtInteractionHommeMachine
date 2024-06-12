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
    private PlayerController playerController;
    private ObjectStorage objectStorage;


    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        objectStorage = FindObjectOfType<ObjectStorage>();
        menuContainer.SetActive(false);
    }

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.E) && !objectStorage.isWeaponSelectorOpen)
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
        playerController.isCameraLock = true;
        menuContainer.SetActive(true);
        menuCanvas.SetActive(true);
        weaponsCanvas.SetActive(false);
        menuActive = true;
    }

    void CloseAllMenus()
    {
        playerController.isCameraLock = false;
        menuContainer.SetActive(false);
        menuCanvas.SetActive(false);
        weaponsCanvas.SetActive(false);
        menuActive = false;
    }
}
