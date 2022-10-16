using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MovableObject : Object
{
    private Rigidbody2D _rb;
    private bool _isMove;
    private bool _inTrigger;
    private int _speed;

    PlayerMovementBase _movingObjectSystem;

    private void Start()
    {
        _isMove = false;
        _inTrigger = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _movingObjectSystem = other.gameObject.GetComponent<PlayerMovementBase>();

            _inTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _inTrigger = false;
        }
    }

    protected void TryMove()
    {     
      
        if (_inTrigger)
        {
          
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isMove = !_isMove;
                if (_isMove)
                {                
                    print(_movingObjectSystem.PlayerMove);
                    gameObject.AddComponent<Rigidbody2D>();
                    _rb = GetComponent<Rigidbody2D>();
                    _rb.bodyType = RigidbodyType2D.Kinematic;
                    _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                   
                } else
                {
                    Destroy(GetComponent<Rigidbody2D>());
                    _rb = null;
                    _movingObjectSystem = null; 
                } 
            }
        }

        if (_isMove)
        {
            _rb.velocity = _movingObjectSystem.PlayerMove ;
        }
    }
}
