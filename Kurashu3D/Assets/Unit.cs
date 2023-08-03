using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int tileX;
    public int tileY;
    public TileMap map;

    int moveSpeed = 2;

    public List<Node> currentPath = null;

    void Update()
    {
        if(currentPath != null)
        {
            int currNode = 0;
            while(currNode < currentPath.Count - 1)
            {
                Vector3 start = map.TileCoordToWorldCoord(currentPath[currNode].x, currentPath[currNode].y) + new Vector3(0, 0.5f, 0);
                Vector3 end = map.TileCoordToWorldCoord(currentPath[currNode+1].x, currentPath[currNode+1].y) + new Vector3(0, 0.5f, 0);;

                Debug.DrawLine(start, end, Color.red);
                currNode++;
            }
        }
    }

    public void TeleportTo(Vector3 vec)
    {
        transform.position = new Vector3(vec.x, transform.position.y, vec.z);
    }

    public void MoveNextTile()
    {
        float remainingMovement = moveSpeed;
        while(remainingMovement > 0)
        {
            if(currentPath == null)
            {
                return;
            }

            //get cost from current tile to next tile
            remainingMovement -= map.CostToEnterTile(currentPath[1].x, currentPath[1].y);
            Debug.Log(map.CostToEnterTile(currentPath[0].x, currentPath[0].y));

            //move us to next tile in sequence
            tileX = currentPath[1].x;
            tileY = currentPath[1].y;
            transform.position = map.TileCoordToWorldCoord(tileX, tileY);
            


            //remove the old current tile
            currentPath.RemoveAt(0);

            if(currentPath.Count == 1)
            {
                currentPath = null;   
            }
        }
        
    }
}
