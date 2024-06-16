using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUpObject : MonoBehaviour
{
    [SerializeField] private TMP_Text objectDisplayer;
    [SerializeField] private GameObject canvasObject;
    public ObjectStorage weaponsStorage;
    private float displayTime = 2f; // Temps d'affichage du canvas en secondes


    void Start()
    {
        canvasObject.SetActive(false);
    }


    void Update()
    {
        Vector3 rayOrigin = Camera.main.transform.position;
        Vector3 rayDirection = Camera.main.transform.forward;

        RaycastHit hit;
        Debug.DrawRay(rayOrigin, rayDirection * 3, Color.red);
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, 3))
        {
            if (hit.collider.gameObject.tag == "PickUpObject")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Weapons weapon = hit.collider.gameObject.GetComponent<Weapons>();
                    if (weapon != null)
                    {
                        weaponsStorage.AddObjectToStorage(weapon);
                        DisplayObjectName(weapon);
                        hit.collider.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    public void DisplayObjectName(Weapons weapon)
    {
        canvasObject.SetActive(true);
        objectDisplayer.text = weapon.weaponName;
        StartCoroutine(HideCanvasAfterDelay(displayTime)); // Cache le canvas après displayTime secondes
    }

    private IEnumerator HideCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canvasObject.SetActive(false);
    }
}
