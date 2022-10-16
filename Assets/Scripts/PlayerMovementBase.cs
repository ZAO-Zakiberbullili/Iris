using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBase : MovementSystem
{
    
    private void Start()
    {
        PlayerMove = Vector2.zero;
    }

    override public void MovePlayer(int playerIndex)
    {
        PlayerMove = new Vector2(_input.Move.x, _input.Move.y);

        _teamRB[playerIndex].velocity = PlayerMove * TeamData[playerIndex].Speed;
    }


    public void FollowPlayer(int playerIndex)
    {
        // плагин
    }
}
