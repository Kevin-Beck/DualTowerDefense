﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadCurLevel : MonoBehaviour
{
    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(0);
    }
}
