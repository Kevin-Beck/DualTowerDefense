using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityInventoryUI : MonoBehaviour
{
    [SerializeField] GameObject togglePrefab;
    [SerializeField] TowerData towerGettingBuilt;
    [SerializeField] TowerData inventoryOfAbilities;
    private int heightGap;
    private int width;

    List<GameObject> myToggles = new List<GameObject>();

    private void Awake()
    {
        inventoryOfAbilities.myAbilities.Clear();
        towerGettingBuilt.myAbilities.Clear();
        heightGap = (int)togglePrefab.GetComponent<RectTransform>().rect.height;
        width = (int)togglePrefab.GetComponent<RectTransform>().rect.width;
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

        int count = 0;
        foreach(TowerAbility ta in inventoryOfAbilities.myAbilities)
        {
            GameObject go = Instantiate(togglePrefab);
            go.GetComponent<TowerSelector>().abilitiesToAdd.Add(ta);
            go.transform.SetParent(gameObject.transform);

            Toggle curToggle = go.GetComponent<Toggle>();
            curToggle.GetComponentInChildren<Text>().text = ta.GetDescription();
            curToggle.GetComponent<RectTransform>().anchoredPosition = new Vector3(-0f*width, -1 * heightGap * count -100, 0);
            count++;
            myToggles.Add(go);
        }
    }

}
