using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseMenu : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private GameObject menuToClose;
    [SerializeField] private GameObject menuContainer;

    private PlayerController playerController;
    private PlaneteMenu planeteMenu;

    void Start()
    {
        planeteMenu = FindAnyObjectByType<PlaneteMenu>();
        playerController = FindAnyObjectByType<PlayerController>();
    }
    void Update()
    {
        closeButton.onClick.AddListener(CloseMenuCanvas);
    }

    public void CloseMenuCanvas()
    {
        planeteMenu.isPlanetSelectorOpen = false;
        playerController.isCameraLock = false;
        menuContainer.SetActive(false);
        menuToClose.SetActive(false);
    }
}
