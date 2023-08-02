using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCursor : MonoBehaviour
{

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
            Debug.Log("Moving");
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
