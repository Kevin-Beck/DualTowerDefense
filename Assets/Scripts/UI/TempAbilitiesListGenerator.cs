﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TempAbilitiesListGenerator : MonoBehaviour
{
    /*
    DirectoryInfo dir;
    FileInfo[] info;
    public GameObject AbilityTickPrefab;
    public Canvas canvasTheySpawnOn;

    // Start is called before the first frame update
    void Start()
    {
        dir = new DirectoryInfo("Assets/GameVariables/TowerAbilities");
        info = dir.GetFiles("*.asset");
        for(int i = 0; i < info.Length; i++)
        {
            string extensionlessname = info[i].Name;
            int index = extensionlessname.IndexOf(".");
            if (index > 0)
                extensionlessname = extensionlessname.Substring(0, index);
            TowerAbility ta = AssetDatabase.LoadAssetAtPath<TowerAbility>("Assets/GameVariables/TowerAbilities/"+extensionlessname + ".asset");
            GameObject go = Instantiate(AbilityTickPrefab);
            go.GetComponent<TowerSelector>().abilitiesToAdd.Add(ta);
            go.transform.position = new Vector3(canvasTheySpawnOn.GetComponent<RectTransform>().position.x+.2f*canvasTheySpawnOn.GetComponent<RectTransform>().sizeDelta.x, canvasTheySpawnOn.GetComponent<RectTransform>().sizeDelta.y- 15 - (20 * i), canvasTheySpawnOn.GetComponent<RectTransform>().position.z);
            go.transform.SetParent(canvasTheySpawnOn.transform);
            go.GetComponent<Toggle>().GetComponentInChildren<Text>().text = extensionlessname;
        }
    }
    */
}
