using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementSystem : MonoBehaviour
{
    public GameObject[] Team;
    public PawnData[] TeamData;

    protected Rigidbody2D[] _teamRB;

    [SerializeField] protected PlayerInput _input;

    protected int _playerIndex = 0;

    public Vector2 PlayerMove { get; protected set; }

    public abstract void MovePlayer(int playerIndex);
}
