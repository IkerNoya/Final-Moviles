using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float distanceAdditive;
    [SerializeField] GameObject victoryScreen;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Text maxDistance;
    [SerializeField] Text distanceToTargetText;


    public static GameManager instance;
    GameObject player;
    LevelManager levelManager;

    float distance;
    float distanceToTarget;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        PlayerController.Win += WinEvent;
        PlayerController.Die += LooseEvent;
        levelManager = FindObjectOfType<LevelManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (levelManager!=null)
            distance = levelManager.GetInitialEndLevelDistance();
    }
    void Update()
    {
        if(player!=null && levelManager!=null)
            distanceToTarget = Vector3.Distance(player.transform.position, levelManager.GetVictoryObject().transform.position);
        distanceToTargetText.text = distanceToTarget.ToString("F2");
    }
    void WinEvent(PlayerController pc)
    {
        if (levelManager != null)
        {
            Time.timeScale = 0;
            if (victoryScreen != null)
                victoryScreen.SetActive(true);
            if (maxDistance != null && player != null)
            {
                maxDistance.text = "MAX DISTANCE\n" + player.GetComponent<PlayerController>().GetDistanceTraveled().ToString("F2");
            }

        }
    }
    void LooseEvent(PlayerController pc)
    {
        if (levelManager != null)
        {
            Time.timeScale = 0;
            if (gameOverScreen != null)
                gameOverScreen.SetActive(true);
            if (maxDistance != null && player != null)
            {
                maxDistance.text = "MAX DISTANCE\n" + player.GetComponent<PlayerController>().GetDistanceTraveled().ToString("F2");
            }

        }
    }
    public void OnClickContinue()
    {
        distance += distanceAdditive;
        if (levelManager != null)
            levelManager.LoadLevel(distance);
        if(victoryScreen!=null)
            victoryScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnClickRestart()
    {
        distance = 100;
        if (levelManager != null)
            levelManager.LoadLevel(distance);
        if (gameOverScreen != null)
            gameOverScreen.SetActive(false);
        Time.timeScale = 1;
    }
    void OnDisable()
    {
        PlayerController.Win -= WinEvent;
        PlayerController.Die -= LooseEvent;
        if (instance != null)
             instance = null;
    }
    void OnDestroy()
    {
        if (instance != null)
            instance = null;
    }
}
