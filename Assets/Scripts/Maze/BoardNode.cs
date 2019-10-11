using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// BoardNode is the script attached to each 'space' in the board.
/// <para>It contains 4 public walls which are removed from outside the class during the maze solving step.</para>
/// <para>BoardNode also contains the reference to the turret positioned on its space if occupied, and also a reference to the data representing the next turret. If a turret is built on this tile, that data is used to build the object in the scene.</para>
/// </summary>
public class BoardNode : MonoBehaviour
{
    /// <summary>
    /// Wall in the positive z direction
    /// </summary>
    public GameObject NorthWall;
    /// <summary>
    /// Wall in the positive x direction
    /// </summary>
    public GameObject EastWall;
    /// <summary>
    /// Wall in the negative z direction
    /// </summary>
    public GameObject SouthWall;
    /// <summary>
    /// Wall in the negative x direction
    /// </summary>
    public GameObject WestWall;

    /// <summary>
    /// Color the tile is initialized to
    /// </summary>
    public Color normalColor;
    /// <summary>
    /// Color when the mouse is hovered over the tile.
    /// </summary>
    public Color hoverColor;

    /// <summary>
    /// Renderer of this object.
    /// </summary>
    Renderer myRender;
    /// <summary>
    /// This is a block of data that is used to alter the color. The color is changed on the block, then applied to the renderer.
    /// </summary>
    MaterialPropertyBlock mpb;

    /// <summary>
    /// This is the turret that is currently in this space. If no turret has been placed on this tile, it is null.
    /// </summary>
    public GameObject myTurret;
    /// <summary>
    /// This is the base turret with no abilities. When a turret is added to the space, this object is created. It is a persistant base copy of what a turret is.
    /// </summary>
    public GameObject baseTurret;

    /// <summary>
    /// This is the reference to the tower abilities that are to be added after the base is created
    /// </summary>
    public TowerData towerToBuild;


    /// <summary>
    /// Renderer and MaterialPropertyBlock are assigned, and the base color is added to the tile.
    /// </summary>
    private void Awake()
    {
        myRender = GetComponent<Renderer>();
        mpb = new MaterialPropertyBlock();
        mpb.SetColor("_BaseColor", normalColor);
        myRender.SetPropertyBlock(mpb);
    }
    /// <summary>
    /// Changes color of the tile when a mouse enters the tile.
    /// </summary>
    private void OnMouseEnter()
    {
        mpb.SetColor("_BaseColor", hoverColor);
        myRender.SetPropertyBlock(mpb);
    }
    /// <summary>
    /// Resets the color to the original base color when the mouse exits.
    /// </summary>
    private void OnMouseExit()
    {
        mpb.SetColor("_BaseColor", normalColor);
        myRender.SetPropertyBlock(mpb);
    }

    /// <summary>
    /// When a mouse button down is register on the tile, the base turret is created and a reference to the
    /// instantiated tower is stored as this space's current tower.
    /// <para>Then each desired ability is added to this current tower.</para>
    /// </summary>
    private void OnMouseDown()
    {
        // Check if the mouse was clicked over a UI element
        if (!EventSystem.current.IsPointerOverGameObject())
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
                PolyTower tower = myTurret.GetComponent<PolyTower>();

                foreach (Effect e in towerToBuild.myAbilities)
                {

                    tower.myEffects.Add(e);
                    e.AlterTower(tower);

                }
                
            }
        }
    }


}
