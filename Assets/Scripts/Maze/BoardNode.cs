using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardNode : MonoBehaviour
{
    public GameObject NorthWall;
    public GameObject EastWall;
    public GameObject SouthWall;
    public GameObject WestWall;

    public Color normalColor;
    public Color hoverColor;
    Renderer myRender;
    MaterialPropertyBlock mpb;

    public GameObject myTurret;
    public GameObject baseTurret; // The turret base which is added onto

    private void Awake()
    {
        myRender = GetComponent<Renderer>();
    }
    private void Start()
    {
        mpb = new MaterialPropertyBlock();
    }
    private void OnMouseEnter()
    {
        mpb.SetColor("_BaseColor", hoverColor);
        myRender.SetPropertyBlock(mpb);
    }
    private void OnMouseExit()
    {
        mpb.SetColor("_BaseColor", normalColor);
        myRender.SetPropertyBlock(mpb);
    }

    private void OnMouseDown()
    {
        if (myTurret != null)
        {
            Debug.Log("Cant Build Here, already have a tower");
            return;
        }
        else
        {
            myTurret = Instantiate(baseTurret, transform.position, transform.rotation);
            myTurret.transform.parent = transform;

        }
    }
    public void UpdateTower(GameObject _turret)
    {
        
        
    }


}
