using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] private GameObject menuContainer;

    [SerializeField] private GameObject planetMenu;

    private PlaneteMenu planeteMenu;

    void Start()
    {
        planeteMenu = FindAnyObjectByType<PlaneteMenu>();
    }

    void Update()
    {
        Vector3 rayOrigin = Camera.main.transform.position;
        Vector3 rayDirection = Camera.main.transform.forward;

        RaycastHit hit;
        Debug.DrawRay(rayOrigin, rayDirection * 3, Color.red);
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, 3))
        {
            if (hit.collider.gameObject.tag == "SpaceShipController")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    planeteMenu.isPlanetSelectorOpen = true;
                    PlayerController.instance.isCameraLock = true;
                    menuContainer.SetActive(true);
                    planetMenu.SetActive(true);
                }
            }
        }
    }


}

