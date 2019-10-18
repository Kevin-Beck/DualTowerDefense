using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(EnemyWalk))]
[RequireComponent(typeof(EnemyHealth))]
public class Enemy : MonoBehaviour
{
    [HideInInspector] public EnemyWalk ewalk;
    [HideInInspector] public EnemyHealth ehealth;

    [SerializeField] Texture myIcon;

    [Header("OverheadParticleConfig")]
    [SerializeField] Vector3 particlePositionOffset = default;

    private void Awake()
    {
        ewalk = GetComponent<EnemyWalk>();
        ehealth = GetComponent<EnemyHealth>();
    }
    public Texture GetEnemyIcon()
    {
        return myIcon;
    }

    public Vector3 GetParticleOffset()
    {
        return particlePositionOffset;
    }
}
