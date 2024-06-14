using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    // private ObjectStorage objectStorage;

    // void Start()
    // {
    //     objectStorage = FindAnyObjectByType<ObjectStorage>();
    // }

    public void LoadScene()
    {
        // if (objectStorage != null)
        // {
        //     DontDestroyOnLoad(objectStorage.gameObject);
        // }
        SceneManager.LoadScene(sceneName);
    }
}

