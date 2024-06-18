using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTraining : MonoBehaviour
{
    [SerializeField] private List<Vector3> prefabTargetPosition;
    public static ShootTraining instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ShootTraining dans la scene");
            return;
        }
        instance = this;
    }

    void Update()
    {
        if(Target.instance.isHit == true || Target.instance.noMoreTargetLife == true)
        {
            Target.instance.target.SetActive(false);
            DisplayNewTarget();
            Target.instance.targetLife = 2f;
            Target.instance.noMoreTargetLife = false;
            Target.instance.isHit = false;
        }
    }

    public void DisplayNewTarget()
    {
        int randomIndex = Random.Range(0, prefabTargetPosition.Count);
        Vector3 targetPosition = prefabTargetPosition[randomIndex];

        Target.instance.target.transform.position = targetPosition;
        Target.instance.target.SetActive(true);
    }

    void Start()
    {
        prefabTargetPosition = new List<Vector3>();

        prefabTargetPosition.Add(new Vector3(-27,1,28));
        prefabTargetPosition.Add(new Vector3(-27,2,28));
        prefabTargetPosition.Add(new Vector3(-27,3,28));
        prefabTargetPosition.Add(new Vector3(-27,1,31));
        prefabTargetPosition.Add(new Vector3(-27,2,31));
        prefabTargetPosition.Add(new Vector3(-27,3,31));
        prefabTargetPosition.Add(new Vector3(-27,1,34));
        prefabTargetPosition.Add(new Vector3(-27,2,34));
        prefabTargetPosition.Add(new Vector3(-27,3,34));
    }


}
