using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float initialEndLevelDistance;
    int levelCount = 0;
    GameObject player;
    [SerializeField] GameObject victoryObject;

    [Space]

    [SerializeField] float spawnTime;
    float timer;

    GameObject[] obstacles;
    GameObject[] spawners;
    ObjectPooler pool;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pool = ObjectPooler.instance;
        //enemy pool
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        spawners = GameObject.FindGameObjectsWithTag("Respawn");
        for(int i = 0; i<obstacles.Length; i++)
        {
            obstacles[i].SetActive(false);
        }

        LoadLevel(initialEndLevelDistance);
    }
    void Update()
    {
        if (timer >= spawnTime)
        {
            pool.SpawnFromPool("Obstacle_1", spawners[Random.Range(0, 3)].transform.position, Quaternion.identity);
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    public void LoadLevel(float distance)
    {
        if(player!=null && victoryObject != null && obstacles!=null)
        {
            for (int i = 0; i < obstacles.Length; i++)
            {
                obstacles[i].SetActive(false);
            }
            player.GetComponent<PlayerController>().Respawn();
            victoryObject.transform.position = new Vector3(player.transform.position.x + distance, 0, 0);
        }
        levelCount++;
    }
    public float GetInitialEndLevelDistance()
    {
        return initialEndLevelDistance;
    }
    public int GetLevelCount()
    {
        return levelCount;
    }

    public GameObject GetVictoryObject()
    {
        return victoryObject;
    }
}
