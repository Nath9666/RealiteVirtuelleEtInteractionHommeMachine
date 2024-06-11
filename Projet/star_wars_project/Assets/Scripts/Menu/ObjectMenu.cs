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

    // void Start()
    // {
    //     menuCanvas.SetActive(false);
    //     weaponsCanvas.SetActive(false);
    // }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
        menuContainer.SetActive(true);
        // menuCanvas.SetActive(true);
        // weaponsCanvas.SetActive(false);
        menuActive = true;
    }

    void CloseAllMenus()
    {
        menuContainer.SetActive(false);
        // menuCanvas.SetActive(false);
        // weaponsCanvas.SetActive(false);
        menuActive = false;
    }
}
