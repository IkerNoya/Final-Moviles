﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void ChagneScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }
}
