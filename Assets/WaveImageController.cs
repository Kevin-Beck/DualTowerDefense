using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveImageController : MonoBehaviour
{
    RawImage myImage;
    Text myCount;
    int count;

    private void Awake()
    {
        myImage = GetComponentInChildren<RawImage>();
        myCount = GetComponentInChildren<Text>();
    }

    public void SetImage(Texture t)
    {
        myImage.texture = t;
    }
    public void SetCount(int c)
    {
        count = c;
        myCount.text = count.ToString();
    }
    public void DecrementCount()
    {
        count--;
        SetCount(count);
    }
    public int GetCount()
    {
        return count;
    }
}
