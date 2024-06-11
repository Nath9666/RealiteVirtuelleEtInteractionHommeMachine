using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInteraction : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        ExitCharacterCollisionArea(collision);
    }

    private void ExitCharacterCollisionArea(Collision collision)
    {
        if (collision.gameObject.CompareTag("PNJ"))
        {
            
            GameObject[] canvases = GameObject.FindGameObjectsWithTag("CanvasPNJ");
            foreach (GameObject canvas in canvases)
            {
                Destroy(canvas);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInteraction : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        ExitCharacterCollisionArea(collision);
    }

    private void ExitCharacterCollisionArea(Collision collision)
    {
        if (collision.gameObject.CompareTag("PNJ"))
        {
            
            GameObject[] canvases = GameObject.FindGameObjectsWithTag("CanvasPNJ");
            foreach (GameObject canvas in canvases)
            {
                Destroy(canvas);
            }
        }
    }
}
