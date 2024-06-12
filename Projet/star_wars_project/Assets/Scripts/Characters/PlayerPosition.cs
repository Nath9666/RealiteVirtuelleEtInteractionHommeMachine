 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] private float dropDistance = 1f;
    [SerializeField] private float dropHeightOffset = 0.5f;
    public Vector3 GetPlayerPosition()
    {
        Vector3 playerPosition = transform.position;
        return playerPosition;
    }

    public Vector3 PositionDroppedWeapon()
    {
        Vector3 playerPos = transform.position;
        Vector3 dropDirection = transform.forward;

        Vector3 weaponPosition = playerPos + dropDirection * dropDistance;

        RaycastHit hit;
        if (Physics.Raycast(weaponPosition, Vector3.down, out hit))
        {
            weaponPosition.y = hit.point.y + dropHeightOffset;
        }

        return weaponPosition;
    }
}