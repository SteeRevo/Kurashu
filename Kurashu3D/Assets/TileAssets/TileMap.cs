using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    public GameObject selectedUnit;
    public TileType[] tileTypes;

    int [,] tiles;

    private GameObject[] gameTiles;

    public List<GameObject> moveableTiles; 

    int mapSizeX = 8;
    int mapSizeY = 6;
    Node[,] graph;

    Vector2 currCursorPos = new Vector2(1, 0);


    //right now we are assuming we only have one unit
    List<Node> currentPath = null;

    void Awake()
    {
        gameTiles = GameObject.FindGameObjectsWithTag("Tile");
    }

    void Start()
    {
        //setup selected unit variables
        selectedUnit.GetComponent<Unit>().tileX = 0;
        selectedUnit.GetComponent<Unit>().tileY = 0;
        selectedUnit.GetComponent<Unit>().map = this;
        



        GenerateMapData();
        GeneratePathfindingGraph();
        GeneratePathTo(selectedUnit.GetComponent<Unit>().tileX, selectedUnit.GetComponent<Unit>().tileY);
        //GenerateMapVisual();
        //FindTile(2, 4);

    }

    void GenerateMapData()
    {
        //allocate map tiles
        tiles = new int[mapSizeX, mapSizeY];

        //initialize map tiles
        for(int x = 0; x < mapSizeX; x++)
        {
            for(int y = 0; y < mapSizeY; y++)
            {
                tiles[x,y] = 0;
            }
        }

        
    }

    public Vector3 UpdateCursorPos(Vector2 vec)
    {
        currCursorPos += vec;
        Debug.Log(currCursorPos);
        return new Vector3(0, 0, 0);
    }

    public float CostToEnterTile(int x, int y)
    {
        TileType tt = tileTypes[tiles[x, y]];

        return tt.movementCost;
    }

    public void FindTile()
    {
        foreach(GameObject tile in gameTiles)
        {
            tile.GetComponent<ClickableTile>().Unselectable();
        }
        foreach(GameObject tile in gameTiles)
        {
            if(tile.GetComponent<ClickableTile>().tileX == currCursorPos.x && tile.GetComponent<ClickableTile>().tileY == currCursorPos.y)
            {
                
                tile.GetComponent<ClickableTile>().setSelectable();
                Debug.Log("found tile at " + currCursorPos.x + ", " + currCursorPos.y);
                Debug.Log(tile.GetComponent<ClickableTile>().GetPosition());
                //selectedUnit.GetComponent<Unit>().TeleportTo(tile.GetComponent<ClickableTile>().GetPosition());
                
            }
        }
    }

    private GameObject FindTileXY(int x, int y)
    {
        foreach(GameObject tile in gameTiles)
        {
            if(tile.GetComponent<ClickableTile>().tileX == x && tile.GetComponent<ClickableTile>().tileY == y)
            {
                
                //Debug.Log("found tile at " + currCursorPos.x + ", " + currCursorPos.y);
                //Debug.Log(tile.GetComponent<ClickableTile>().GetPosition());
                return tile;
                
            }
            
        }

        Debug.Log("error with tile " + x + " " + y);
        return null;
    }

    

    void GeneratePathfindingGraph()
    {
        //initialize the array
        graph = new Node[mapSizeX, mapSizeY];

        //initialie each node in the array
        for(int x = 0; x < mapSizeX; x++)
        {
            for(int y = 0; y < mapSizeY; y++)
            {
                graph[x,y] = new Node();
            }
        }

        //calculate neighbors

        for(int x = 0; x < mapSizeX; x++)
        {
            for(int y = 0; y < mapSizeY; y++)
            {

                graph[x,y].x = x;
                graph[x,y].y = y;
                if(x > 0)
                {
                    graph[x,y].neighbors.Add(graph[x-1, y]);
                }
                if(x < mapSizeX - 1)
                {
                    graph[x,y].neighbors.Add(graph[x+1, y]);
                }
                if(y > 0 )
                {
                    graph[x,y].neighbors.Add(graph[x, y-1]);
                }
                if(y < mapSizeY - 1)
                {
                    graph[x,y].neighbors.Add(graph[x, y+1]);
                }
                
            }
        }
    }

    void GenerateMapVisual()
    {
        for(int x = 0; x < mapSizeX; x++)
        {
            for(int y = 0; y < mapSizeY; y++)
            {
                TileType tt = tileTypes[tiles[x,y]];
                GameObject go = Instantiate(tt.tileVisualPrefab, new Vector3(x, 0, y), Quaternion.identity);
                ClickableTile ct = go.GetComponent<ClickableTile>();
                ct.tileX = x;
                ct.tileY = y;
                ct.map = this;
            }
        }
    }

    public Vector3 TileCoordToWorldCoord(int x, int y)
    {
        foreach(GameObject tile in gameTiles)
        {
            if(tile.GetComponent<ClickableTile>().tileX == x && tile.GetComponent<ClickableTile>().tileY == y)
            {
                return tile.transform.position;
            }
        }
        return new Vector3(0, 0, 0);
    }

    public void GeneratePathTo(int x, int y)
    {
        

        
        //clear old path
        selectedUnit.GetComponent<Unit>().currentPath = null;

        Dictionary<Node, float> dist = new Dictionary<Node, float>();
        Dictionary<Node, Node> prev = new Dictionary<Node, Node>();
        int [,] cost = new int[mapSizeX, mapSizeY];

        List<Node> unvisited = new List<Node>();

        Node source = graph[selectedUnit.GetComponent<Unit>().tileX, selectedUnit.GetComponent<Unit>().tileY];
        //Node target = graph[x, y];

        dist[source] = 0;
        prev[source] = null;

        //initialize everything to infinity distance
        foreach(Node v in graph)
        {
            if(v != source)
            {
                dist[v] = Mathf.Infinity;
                prev[v] = null;
            }

            unvisited.Add(v);
        }
        while(unvisited.Count > 0)
        {
            //u is unvisited node with the smallest distance
            Node u = null;

            foreach(Node possibleU in unvisited)
            {
                if(u == null || dist[possibleU] < dist[u])
                {
                    u = possibleU;
                }

            }

            /*

            if(u == target)
            {
                break;
            }*/

            unvisited.Remove(u);

            foreach(Node v in u.neighbors)
            {
                float alt = dist[u] + CostToEnterTile(v.x, v.y);
                if(alt < dist[v])
                {
                    dist[v] = alt;
                    prev[v] = u;
                }

                cost[v.x, v.y] = cost[u.x, u.y] + (int)CostToEnterTile(v.x, v.y);
                if(selectedUnit.GetComponent<Unit>().get_moveSpeed() - cost[v.x, v.y] >= 0)
                {
                    moveableTiles.Add(FindTileXY(v.x, v.y));
                }
            }
        }

        //if here we found the shorted route to target or there is no route at all
        /*if(prev[target] == null)
        {
            //no route between target and source

            return;
        }
        
        currentPath = new List<Node>();

        Node curr = target;

        while(curr != null)
        {
            currentPath.Add(curr);
            curr = prev[curr];
        }

        currentPath.Reverse();
        selectedUnit.GetComponent<Unit>().currentPath = currentPath;
        */

        SetSelectableTiles();

        //Debug.Log(moveableTiles);

    }

    private void SetSelectableTiles()
    {
        foreach(GameObject tile in moveableTiles)
        {
            tile.GetComponent<ClickableTile>().setSelectable();
            Debug.Log("Set selectable " + tile.GetComponent<ClickableTile>().tileX + " " + tile.GetComponent<ClickableTile>().tileY);
        }

        //moveableTiles[0].GetComponent<ClickableTile>().setSelectable();
       
    }


    
}
