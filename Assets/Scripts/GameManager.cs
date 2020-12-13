using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnDisable()
    {
        if (instance != null)
             instance = null;
    }
    private void OnDestroy()
    {
        if (instance != null)
            instance = null;
    }
}
