using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    [SerializeField] Spawner mySpawner;
    [SerializeField] GameObject iconPrefab;
    [SerializeField] RectTransform contentFrame;
    [SerializeField] GameObject panel;
    [SerializeField] Button minimizeButton;
    [SerializeField] int posx = 50;
    [SerializeField] int posy = -40;
    List<WaveImageController> myWics = new List<WaveImageController>();
    Wave nextWave = default;
    int sequenceIndex = 0;
    bool shift = false;
    Vector2 shiftTarget;
    bool minimized = false;

    private void Start()
    {
        GetNextWaveData();
        GenerateImages();        
    }
    private void GetNextWaveData()
    {
        nextWave = mySpawner.GetNextWaveData();
    }
    public void Minimize()
    {
        panel.GetComponent<RectTransform>().anchoredPosition *= -1;
        minimizeButton.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 1), 180);        
    }
    private void GenerateImages()
    {
        sequenceIndex = 0;
        EnableShift();
        for(int i = 0; i < nextWave.sequences.Count; i++)
        {
            GameObject go = Instantiate(iconPrefab);
            go.transform.SetParent(contentFrame.transform);
            go.GetComponent<RectTransform>().anchoredPosition = new Vector3(50, -80 * i -40);
            WaveImageController wic = go.GetComponent<WaveImageController>();
            wic.SetCount(nextWave.sequences[i].GetEnemyCount());
            wic.SetImage(nextWave.sequences[i].GetEnemy().GetComponent<AnimatedEnemy>().GetEnemyIcon());
            myWics.Add(wic);
        }
    }
    private void FixedUpdate()
    {
        
        if (shift)
        {
            contentFrame.anchoredPosition = Vector2.Lerp(contentFrame.anchoredPosition, shiftTarget, Time.deltaTime);
            if (Vector2.SqrMagnitude(contentFrame.anchoredPosition - shiftTarget) < 5f)
                DisableShift();
        }
        
    }
    private void EnableShift()
    {
        shiftTarget = new Vector3(0f, 80 * sequenceIndex);
        shift = true;
    }
    private void DisableShift()
    {
        shift = false;
    }
    public void DecrementCurrentWaveIcon()
    {
        if (myWics[sequenceIndex].GetCount() == 0)
        {
            sequenceIndex++;
            EnableShift();
        }
        if (sequenceIndex < nextWave.sequences.Count)
            myWics[sequenceIndex].DecrementCount();

    }
    private void ClearWaveImages()
    {
        while(myWics.Count > 0)
        {
            Destroy(myWics[0].gameObject);
            myWics.RemoveAt(0);
        }
    }

    public void GenerateNextWaveImages()
    {
        ClearWaveImages();
        GetNextWaveData();
        if(nextWave != null)
            GenerateImages();
    }

}
