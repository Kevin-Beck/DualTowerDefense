using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerEffect : Effect
{
    abstract public void AlterTower(PolyTower ts); // used to change the range of the tower etc
    abstract public GameObject GetTowerParticles(); // used to make a visual effect on the tower;
}
