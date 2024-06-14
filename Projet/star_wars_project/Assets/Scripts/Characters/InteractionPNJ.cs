using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractionPNJ : MonoBehaviour
{
    [SerializeField] private Dialog dialog;
    [SerializeField] public GameObject dialogContainer;
    public bool isInRange = false;
    public static InteractionPNJ instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de InteractionPNJ dans la scene");
            return;
        }
        instance = this;
    }

    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.F))
        {
            TriggerDialog();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    private void TriggerDialog()
    {
        dialogContainer.SetActive(true);
        PlayerController.instance.isCameraLock = true;
        DialogManager.instance.isDialogOpen = true;
        DialogManager.instance.StartDialog(dialog);
    }

}

