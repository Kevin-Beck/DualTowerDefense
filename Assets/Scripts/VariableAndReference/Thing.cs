
using UnityEngine;


public class Thing : MonoBehaviour
{
    public ThingRuntimeSet RuntimeSet;

    private void OnEnable()
    {
        RuntimeSet.Add(this);
    }
    public void RemoveMe()
    {
        RuntimeSet.Remove(this);
    }
    private void OnDisable()
    {
        RuntimeSet.Remove(this);
    }
}

