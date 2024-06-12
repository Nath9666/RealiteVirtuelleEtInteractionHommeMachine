using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] private float dropDistance = 1f;
    public Vector3 GetPlayerPosition()
    {
        Vector3 playerPosition = transform.position;
        return playerPosition;
    }

    public Vector3 PositionDroppedWeapon()
    {
        Vector3 playerPos = GetPlayerPosition();
        Vector3 dropDirection = transform.forward;


        Vector3 weaponPosition = playerPos + dropDirection * dropDistance;
        return weaponPosition;
    }
}
