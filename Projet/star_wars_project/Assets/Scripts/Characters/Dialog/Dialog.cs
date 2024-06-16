using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    [SerializeField] public string namePNJ;

    [TextArea(3, 10)]
    [SerializeField] public string[] sentences;
    [SerializeField] public AudioClip[] audioClips;
}
