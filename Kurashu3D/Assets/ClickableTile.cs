using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile : MonoBehaviour
{
    public int tileX;
    public int tileY;
    public TileMap map;

   
    //map.GeneratePathTo(tileX, tileY);

    void OnMouseUp()
    {
        map.GeneratePathTo(tileX, tileY);
    }



    public Vector3 GetPosition()
    {
        return new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    
}
