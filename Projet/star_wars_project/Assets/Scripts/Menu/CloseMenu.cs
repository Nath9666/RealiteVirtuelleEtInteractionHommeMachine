using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseMenu : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private GameObject menuToClose;
    [SerializeField] private GameObject menuContainer;

    private PlaneteMenu planeteMenu;

    void Start()
    {
        planeteMenu = FindAnyObjectByType<PlaneteMenu>();
    }
    void Update()
    {
        closeButton.onClick.AddListener(CloseMenuCanvas);
    }

    public void CloseMenuCanvas()
    {
        planeteMenu.isPlanetSelectorOpen = false;
        PlayerController.instance.isCameraLock = false;
        menuContainer.SetActive(false);
        menuToClose.SetActive(false);
    }
}
