using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float initialEndLevelDistance;

    GameObject player;
    [SerializeField] GameObject victoryObject;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        LoadLevel(initialEndLevelDistance);
    }

    public void LoadLevel(float distance)
    {
        if(player!=null && victoryObject != null)
        {
            player.transform.position = Vector3.zero;
            victoryObject.transform.position = new Vector3(player.transform.position.x + distance, 0, 0);
        }
    }
    public float GetInitialEndLevelDistance()
    {
        return initialEndLevelDistance;
    }
}
