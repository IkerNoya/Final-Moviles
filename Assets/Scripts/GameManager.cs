using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float distanceAdditive;

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
        distance = levelManager.GetInitialEndLevelDistance();
    }
    void Update()
    {
        
    }
    void WinEvent(PlayerController pc)
    {
        levelManager.LoadLevel(distance + distanceAdditive);
    }
    private void OnDisable()
    {
        PlayerController.Win -= WinEvent;
        if (instance != null)
             instance = null;
    }
    private void OnDestroy()
    {
        if (instance != null)
            instance = null;
    }
}
