using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " New Wave", menuName = "Enemy Wave/New Wave")]
public class Wave : ScriptableObject
{
    [SerializeField] string description;
    [SerializeField] public List<EnemySequence> sequences;
    [SerializeField] float timeBetweenWaves;
    
}
