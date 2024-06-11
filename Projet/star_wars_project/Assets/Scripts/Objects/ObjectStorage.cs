using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectStorage : MonoBehaviour
{
    public List<Weapons> weaponsInStorage = new List<Weapons>();
    [SerializeField] private GameObject menuContainter;
    [SerializeField] private GameObject weaponsMenu;

    [SerializeField] private TMP_Text weaponNameInputOne;
    [SerializeField] private TMP_Text weaponNameInputTwo;
    [SerializeField] private TMP_Text weaponNameInputThree;

    public void AddObjectToStorage(Weapons objet)
    {
        if (weaponsInStorage.Count < 2)
        {
            weaponsInStorage.Add(objet);
        }
        else
        {
            weaponsInStorage.Add(objet);
            menuContainter.SetActive(true);
            weaponsMenu.SetActive(true);

            // Réinitialiser les textes
            weaponNameInputOne.text = "";
            weaponNameInputTwo.text = "";
            weaponNameInputThree.text = "";

            // Afficher les noms des armes
            if (weaponsInStorage.Count > 0)
                weaponNameInputOne.text = weaponsInStorage[0].weaponName;
            if (weaponsInStorage.Count > 1)
                weaponNameInputTwo.text = weaponsInStorage[1].weaponName;
            if (weaponsInStorage.Count > 2)
                weaponNameInputThree.text = weaponsInStorage[2].weaponName;

            Debug.Log("Le sac est plein");
        }
    }
}
