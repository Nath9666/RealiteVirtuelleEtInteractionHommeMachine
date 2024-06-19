using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShootTraining : MonoBehaviour
{
    [SerializeField] private GameObject containerCanvas;
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject pointContainer;
    [SerializeField] private TMP_Text gamePointInput;
    [SerializeField] private GameObject rules;
    [SerializeField] private Button button;
    [SerializeField] private List<Vector3> prefabTargetPosition;
    
    public static ShootTraining instance;
    private bool isInShootArea = false;
    private bool isGameStarted = false;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ShootTraining dans la scene");
            return;
        }
        instance = this;
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            containerCanvas.SetActive(true);
            title.SetActive(true);
            isInShootArea = true;

        }
    }

    public void StartGame()
    {
        rules.SetActive(false);
        timer.SetActive(true);
        pointContainer.SetActive(true);
        isGameStarted = true;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            title.SetActive(false);
            containerCanvas.SetActive(false);
        }
    }

    void Update()
    {
        //affichage des canvas de presentation du jeu
        if(isInShootArea)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                rules.SetActive(true);
            }
        }


        if(Target.instance.isHit == true)
        {
            Target.instance.gamePoint += 1;
            gamePointInput.text = "Points : " + Target.instance.gamePoint;

            Target.instance.target.SetActive(false);
            DisplayNewTarget();
            Target.instance.targetLife = 2f;
            Target.instance.isHit = false;
        }
        else if(Target.instance.noMoreTargetLife == true)
        {
            Target.instance.target.SetActive(false);
            DisplayNewTarget();
            Target.instance.targetLife = 2f;
            Target.instance.noMoreTargetLife = false;
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
        
        prefabTargetPosition.Add(new Vector3(-30,1,28));
        prefabTargetPosition.Add(new Vector3(-30,2,28));
        prefabTargetPosition.Add(new Vector3(-30,3,28));
        prefabTargetPosition.Add(new Vector3(-30,1,31));
        prefabTargetPosition.Add(new Vector3(-30,2,31));
        prefabTargetPosition.Add(new Vector3(-30,3,31));
        prefabTargetPosition.Add(new Vector3(-30,1,34));
        prefabTargetPosition.Add(new Vector3(-30,2,34));
        prefabTargetPosition.Add(new Vector3(-30,3,34));

        prefabTargetPosition.Add(new Vector3(-33,1,28));
        prefabTargetPosition.Add(new Vector3(-33,2,28));
        prefabTargetPosition.Add(new Vector3(-33,3,28));
        prefabTargetPosition.Add(new Vector3(-33,1,31));
        prefabTargetPosition.Add(new Vector3(-33,2,31));
        prefabTargetPosition.Add(new Vector3(-33,3,31));
        prefabTargetPosition.Add(new Vector3(-33,1,34));
        prefabTargetPosition.Add(new Vector3(-33,2,34));
        prefabTargetPosition.Add(new Vector3(-33,3,34)); 


        button.onClick.AddListener(StartGame);       
    }


}
