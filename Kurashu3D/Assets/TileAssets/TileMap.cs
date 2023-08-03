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

    int mapSizeX = 10;
    int mapSizeY = 10;
    Node[,] graph;


    //right now we are assuming we only have one unit
    List<Node> currentPath = null;

    void Awake()
    {
        gameTiles = GameObject.FindGameObjectsWithTag("Tile");
    }

    void Start()
    {
        //setup selected unit variables
        selectedUnit.GetComponent<Unit>().tileX = (int)selectedUnit.transform.position.x;
        selectedUnit.GetComponent<Unit>().tileY = (int)selectedUnit.transform.position.z;
        selectedUnit.GetComponent<Unit>().map = this;
        


        GenerateMapData();
        GeneratePathfindingGraph();
        //GenerateMapVisual();
        FindTile(2, 4);

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

        for(int x = 3; x < 6; x++)
        {
            for(int y = 0; y < 4; y++)
            {
                tiles[x,y] = 1;
            }
        }

        tiles[4,4] = 2;
        tiles[5,4] = 2;
        tiles[6,4] = 2;
        tiles[7,4] = 2;
        tiles[8,4] = 2;

        tiles[4,5] = 2;
        tiles[4,6] = 2;
        tiles[8,5] = 2;
        tiles[8,6] = 2;
    }

    public float CostToEnterTile(int x, int y)
    {
        TileType tt = tileTypes[tiles[x, y]];

        return tt.movementCost;
    }

    public void FindTile(int x, int y)
    {
        foreach(GameObject tile in gameTiles)
        {
            if(tile.GetComponent<ClickableTile>().tileX == x && tile.GetComponent<ClickableTile>().tileY == y)
            {
                Debug.Log("found tile at " + x + ", " + y);
                Debug.Log(tile.GetComponent<ClickableTile>().GetPosition());
                selectedUnit.GetComponent<Unit>().TeleportTo(tile.GetComponent<ClickableTile>().GetPosition());
                
            }
        }
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
        return new Vector3(x, 0, y);
    }

    public void GeneratePathTo(int x, int y)
    {

        
        //clear old path
        selectedUnit.GetComponent<Unit>().currentPath = null;

        Dictionary<Node, float> dist = new Dictionary<Node, float>();
        Dictionary<Node, Node> prev = new Dictionary<Node, Node>();

        List<Node> unvisited = new List<Node>();

        Node source = graph[selectedUnit.GetComponent<Unit>().tileX, selectedUnit.GetComponent<Unit>().tileY];
        Node target = graph[x, y];

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

            if(u == target)
            {
                break;
            }

            unvisited.Remove(u);

            foreach(Node v in u.neighbors)
            {
                float alt = dist[u] + CostToEnterTile(v.x, v.y);
                if(alt < dist[v])
                {
                    dist[v] = alt;
                    prev[v] = u;
                }
            }
        }
        //if here we found the shorted route to target or there is no route at all
        if(prev[target] == null)
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
    }


    
}
