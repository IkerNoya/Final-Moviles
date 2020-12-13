using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float distanceAdditive;
    [SerializeField] GameObject victoryScreen;
    [SerializeField] Text maxDistance;

    public static GameManager instance;
    GameObject player;
    LevelManager levelManager;


    float distance;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        PlayerController.Win += WinEvent;
        levelManager = FindObjectOfType<LevelManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (levelManager!=null)
            distance = levelManager.GetInitialEndLevelDistance();
    }
    void Update()
    {
        
    }
    void WinEvent(PlayerController pc)
    {
        if (levelManager != null)
        {
            if (levelManager.GetLevelCount() < 10)
            {
                Time.timeScale = 0;
                if (victoryScreen != null)
                    victoryScreen.SetActive(true);
                if (maxDistance != null && player!=null)
                {
                    maxDistance.text = "MAX DISTANCE\n" + player.GetComponent<PlayerController>().GetDistanceTraveled().ToString();
                }
            }
            else
            {
                //terminar juego
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
    void OnDisable()
    {
        PlayerController.Win -= WinEvent;
        if (instance != null)
             instance = null;
    }
    void OnDestroy()
    {
        if (instance != null)
            instance = null;
    }
}
