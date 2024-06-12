using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public Vector3 GetPlayerPosition()
    {
        Vector3 playerPosition = transform.position;
        return playerPosition;
    }
}
