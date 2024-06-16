using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] private float dropDistance = 2f;
    [SerializeField] private float holdDistance = 2f;
    [SerializeField] private float holdOffset = 1.0f;
    [SerializeField] private float dropHeightOffset = 0.5f;

    public static PlayerPosition instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Il y a plus d'une instance PlayerPosition dans la scene");
            return;
        }
        instance = this;
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

    public Vector3 PositionHoldWeapon()
    {
        Vector3 playerPos = transform.position;
        Vector3 playerForward = transform.forward;
        Vector3 playerRight = transform.right;

        float holdDistance = 1.0f;
        float verticalOffset = 1.0f;

        Vector3 offsetRight = playerRight * 0.5f;

        Vector3 weaponHoldPos = playerPos + playerForward * holdDistance + offsetRight + Vector3.up * verticalOffset;

        return weaponHoldPos;
    }



}
