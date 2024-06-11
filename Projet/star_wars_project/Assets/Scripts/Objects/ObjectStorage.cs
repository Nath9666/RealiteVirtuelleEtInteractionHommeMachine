using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStorage : MonoBehaviour
{
    public List<GameObject> weaponsInStorage = new List<GameObject>();

    public void AddObjectToStorage(GameObject objet)
    {
        weaponsInStorage.Add(objet);
    }

}
