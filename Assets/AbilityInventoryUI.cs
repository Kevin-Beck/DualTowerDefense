using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityInventoryUI : MonoBehaviour
{
    [SerializeField] GameObject togglePrefab = null;
    [SerializeField] TowerData towerGettingBuilt = null;
    [SerializeField] TowerData inventoryOfAbilities = null;
    [SerializeField] GameObject content = null;
    private int heightGap = default;
    private int width = default; 

    List<GameObject> myToggles = new List<GameObject>();

    private void Awake()
    {
        inventoryOfAbilities.myAbilities.Clear();
        towerGettingBuilt.myAbilities.Clear();
        UpdateUI();
    }
    public void UpdateTowerInventory()
    {
        while(towerGettingBuilt.myAbilities.Count > 0)
        {
            inventoryOfAbilities.myAbilities.Remove(towerGettingBuilt.myAbilities[0]);
            towerGettingBuilt.myAbilities.RemoveAt(0);
        }
    }
    public void UpdateUI()
    {
        foreach (GameObject go in myToggles)
            Destroy(go);
        myToggles.Clear();

        for(int i = 0; i < inventoryOfAbilities.myAbilities.Count; i++)
        {
            GameObject go = Instantiate(togglePrefab);
            go.transform.SetParent(content.transform);
            go.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -50 * i - 25);
            TowerSelector ts = go.GetComponent<TowerSelector>();
            ts.SetImage(inventoryOfAbilities.myAbilities[i].GetIcon());
            ts.abilitiesToAdd.Add(inventoryOfAbilities.myAbilities[i]);
            myToggles.Add(go);
        }

    }

}
