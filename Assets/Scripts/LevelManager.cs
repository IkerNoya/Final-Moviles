﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float initialEndLevelDistance;
    int levelCount = 0;
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
