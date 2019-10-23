using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(AnimatedEnemyWalk))]
[RequireComponent(typeof(AnimatedEnemyHealth))]
public class AnimatedEnemy : MonoBehaviour
{
    [HideInInspector] public AnimatedEnemyWalk ewalk;
    [HideInInspector] public AnimatedEnemyHealth ehealth;

    [Header("My Icon")]
    [SerializeField] Texture myIcon;

    [Header("My Death Event")]
    [SerializeField] GameEvent DeathEvent;

    [Header("Animation")]
    [SerializeField] string walkAnimationName;
    [SerializeField] string deathAnimationName;
    [SerializeField] Vector3 deathSinkTarget = new Vector3(0, -8, 0);
    [SerializeField] float sinkDelay = 1.5f;
    public bool isDead = false;
    bool sink = false;
    Animator anim;

    [Header("OverheadParticleConfig")]
    [SerializeField] Vector3 overheadOffset = default;

    [Header("My Center")]
    [SerializeField] Vector3 heightOfCenter = default;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        ewalk = GetComponent<AnimatedEnemyWalk>();
        ehealth = GetComponent<AnimatedEnemyHealth>();

        anim.SetBool(walkAnimationName, true);
    }
    public void DeSpawn()
    {
        DeathEvent.Raise();
        GetComponent<Thing>().RemoveMe();
        Destroy(gameObject);
    }
    public void Die()
    {
        GetComponent<Thing>().RemoveMe();
        DeathEvent.Raise();
        ewalk.curSpeed = 0;
        ewalk.speed = 0;
       
        anim.SetBool(walkAnimationName, false);
        anim.SetBool(deathAnimationName, true);
        deathSinkTarget = new Vector3(transform.position.x, transform.position.y+deathSinkTarget.y, transform.position.z);
        isDead = true;
        StartCoroutine("Sink");
    }
    private void Update()
    {
        if (isDead)
        {
            if (sink)
            {
                transform.position = Vector3.Lerp(transform.position, deathSinkTarget, .3f*Time.fixedDeltaTime);
                if (transform.position.y < -6)
                    Destroy(gameObject);
            }
        }
    }
    public Texture GetEnemyIcon()
    {
        return myIcon;
    }
    public Vector3 GetOverheadOffset()
    {
        return overheadOffset;
    }
    public Vector3 GetHeight()
    {
        return heightOfCenter;
    }
    IEnumerator Sink()
    {
        yield return new WaitForSeconds(sinkDelay);
        sink = true;
    }
}