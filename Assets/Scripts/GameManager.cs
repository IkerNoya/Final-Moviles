using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float distanceAdditive;
    [SerializeField] GameObject victoryScreen;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Text maxDistanceVictory;
    [SerializeField] Text maxDistanceGameOver;
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
        Time.timeScale = 1;
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
            if (maxDistanceVictory != null && player != null)
            {
                maxDistanceVictory.text = "MAX DISTANCE\n" + player.GetComponent<PlayerController>().GetDistanceTraveled().ToString("F2");
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
            if (maxDistanceVictory != null && player != null)
            {
                maxDistanceGameOver.text = "MAX DISTANCE\n" + player.GetComponent<PlayerController>().GetDistanceTraveled().ToString("F2");
            }

        }
    }
    public void OnClickContinue()
    {
        Time.timeScale = 1;
        distance += distanceAdditive;
        if (levelManager != null)
            levelManager.LoadLevel(distance);
        if(victoryScreen!=null)
            victoryScreen.SetActive(false);
    }
    public void OnClickRestart()
    {
        Time.timeScale = 1;
        distance = 100;
        if (levelManager != null)
            levelManager.LoadLevel(distance);
        if (gameOverScreen != null)
            gameOverScreen.SetActive(false);
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
