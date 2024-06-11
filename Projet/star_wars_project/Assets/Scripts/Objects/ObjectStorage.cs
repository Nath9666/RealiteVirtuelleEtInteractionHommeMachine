using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectStorage : MonoBehaviour
{
    public List<GameObject> weaponsInStorage = new List<GameObject>();
    [SerializeField] private GameObject menuContainter;
    [SerializeField] private GameObject weaponsMenu;

    [SerializeField] private TMP_Text weaponNameInputOne;
    [SerializeField] private TMP_Text weaponNameInputTwo;

    public void AddObjectToStorage(GameObject objet)
    {
        if(weaponsInStorage.Count < 2)
        {
            weaponsInStorage.Add(objet);
        }
        else 
        {
            menuContainter.SetActive(true);
            weaponsMenu.SetActive(true);
            foreach (GameObject obj in weaponsInStorage)
            {
                if(weaponNameInputOne.text != "")
                {
                    weaponNameInputTwo.text = obj.name;
                } 
                else 
                {
                    weaponNameInputOne.text = obj.name;
                }
            }
            Debug.Log("Le sac est plein");
        }
        
    }
}