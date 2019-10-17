using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPool
{
    [SerializeField] List<TowerAbility> abilities = new List<TowerAbility>();

    public AbilityPool(TowerData td)
    {
        foreach (TowerAbility ta in td.myAbilities)
            abilities.Add(ta);
    }

    public TowerAbility GetAbilityFromPool()
    {
        if(abilities.Count > 0)
        {
            Shuffle();
            TowerAbility nextAbility = abilities[0];
            abilities.RemoveAt(0);
            return nextAbility;
        }
        return null;
    }
    public void AddAbilityToPool(TowerAbility ta)
    {
        abilities.Add(ta);
    }
    private void Shuffle()
    {
        var count = abilities.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = abilities[i];
            abilities[i] = abilities[r];
            abilities[r] = tmp;
        }
    }
}
