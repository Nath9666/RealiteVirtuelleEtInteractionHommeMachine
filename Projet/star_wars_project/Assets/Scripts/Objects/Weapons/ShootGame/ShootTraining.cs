using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShootTraining : MonoBehaviour
{
    [SerializeField] private GameObject containerCanvas;
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject resultContainer;
    [SerializeField] private TMP_Text result;
    [SerializeField] private GameObject timer;
    [SerializeField] private TMP_Text timerInput;
    [SerializeField] private float defaultTimer = 30f;
    [SerializeField] private GameObject pointContainer;
    [SerializeField] private TMP_Text gamePointInput;
    [SerializeField] private GameObject rules;
    [SerializeField] private Button button;
    [SerializeField] private List<Vector3> prefabTargetPosition;
    
    public static ShootTraining instance;
    private bool isInShootArea = false;
    private float timeRemaining;

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
        title.SetActive(false);
        rules.SetActive(false);
        timer.SetActive(true);
        pointContainer.SetActive(true);
        timeRemaining = defaultTimer;
        Target.instance.isStart = true;
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
                PlayerController.instance.isCameraLock = true;
                rules.SetActive(true);
            }
        }

        if(Target.instance.isStart)
        {
            PlayerController.instance.isCameraLock = false;
            UpdateTimer();
        }


        if(Target.instance.isHit == true)
        {
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

    void UpdateTimer()
    {
        if (timeRemaining >= 0)
        {
            timeRemaining -= Time.deltaTime;
            timerInput.text = Mathf.CeilToInt(timeRemaining).ToString() + "s";
        }
        else
        {
            PlayerController.instance.isCameraLock = true;
            timer.SetActive(false);
            pointContainer.SetActive(false);
            resultContainer.SetActive(true);
            result.text = "Vous avez marqué " + Target.instance.gamePoint + " points en 30 secondes !";

            Target.instance.gamePoint = 0;
            Target.instance.isStart = false;
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
