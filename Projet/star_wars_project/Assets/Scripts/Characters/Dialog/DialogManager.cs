using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private TMP_Text nameInput;
    [SerializeField] private TMP_Text dialogInput;

    private Queue<string> sentences;
    public bool isDialogOpen = false;
    public static DialogManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DialogManager dans la scene");
            return;
        }
        instance = this;
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        nameInput.text = dialog.namePNJ;
        
        sentences.Clear();
        foreach(string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogInput.text = sentence;
    }

    void EndDialog()
    {
        PlayerController.instance.isCameraLock = false;
        InteractionPNJ.instance.dialogContainer.SetActive(false);
        Debug.Log("Le dialogue est fini");
    }

}
