﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "TowerData/new TowerData")]
public class TowerData : ScriptableObject
{
    public List<TowerAbility> myAbilities = new List<TowerAbility>();
}
