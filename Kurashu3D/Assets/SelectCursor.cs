using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectCursor : MonoBehaviour
{
    bool isMoving = false;
    public TileMap tilemap;

    private PlayerControls _input;

    void Awake()
    {
        _input = new PlayerControls();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = _input.PlayerBattleTurn.Move.ReadValue<Vector2>().normalized;

        if(!(move ==  new Vector2(0, 0)))
        {
            if(!isMoving)
            {
                tilemap.GetComponent<TileMap>().UpdateCursorPos(move);
                transform.position += new Vector3(move.x, 0, move.y);   
                isMoving = true; 
            }
        }
        else{
            isMoving = false;
        }
       

    }

    



    void OnEnable()
    {
        _input.PlayerBattleTurn.Enable();
        
    }

    void OnDisable()
    {
        _input.PlayerBattleTurn.Disable();
    }

 
}
