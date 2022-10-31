using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MovableObject : Object
{
    private Rigidbody2D _rb;
    private bool _isMove;
    private List <Player> _player = new List<Player>();

    public bool IsMovable { get; protected set; }


    private void Start()
    {
        _isMove = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (Player player in _player)
            {
                if (other.gameObject.Equals(player.gameObject))
                    return;
            }
            _player.Add(other.gameObject.GetComponent<Player>());
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (Player player in _player)
            {
                if (other.gameObject.Equals(player.gameObject))
                {
                    _player.Remove(player);
                    return;
                }
            }

        }
    }

    protected void TryMove()
    {     
        if (IsMovable)
        {
            int activePlayerIndex;
            for (activePlayerIndex = 0; activePlayerIndex < _player.Count; activePlayerIndex++)
            {

                if (_player[activePlayerIndex].IsActive)
                {
                    break;
                }

            }

            if (activePlayerIndex == _player.Count)
            {
                if (_isMove)
                {
                    _rb = null;
                    foreach (Player player in _player)
                        player.IsMoveObject = false;
                    _isMove = false;
                    Destroy(GetComponent<Rigidbody2D>());
                }

                return;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isMove = !_isMove;

                _player[activePlayerIndex].IsMoveObject = _isMove;
                if (_isMove)
                {
                    gameObject.AddComponent<Rigidbody2D>();
                    _rb = GetComponent<Rigidbody2D>();
                    _rb.bodyType = RigidbodyType2D.Kinematic;
                    _rb.constraints = RigidbodyConstraints2D.FreezeRotation;

                }
                else
                {
                    Destroy(GetComponent<Rigidbody2D>());
                    _rb = null;
                }
            }

            if (_isMove)
            {
                _rb.velocity = _player[activePlayerIndex].Direction
                    * _player[activePlayerIndex].Speed * _player[activePlayerIndex].CarryingSpeedfactor;
            }
        }  
    }

}


//OLD VERSION
/*using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MovableObject : Object
{
    private Rigidbody2D _rb;
    private bool _isMove;
    private bool _inTrigger;
    private int _speed;

    Player _player;

    private void Start()
    {
        _isMove = false;
        _inTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _player = other.gameObject.GetComponent<Player>();

            _inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _inTrigger = false;
        }
    }

    protected void TryMove()
    {

        if (_inTrigger && IsMovable)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isMove = !_isMove;
                _player.IsMoveObject = _isMove;
                if (_isMove)
                {
                    gameObject.AddComponent<Rigidbody2D>();
                    _rb = GetComponent<Rigidbody2D>();
                    _rb.bodyType = RigidbodyType2D.Kinematic;
                    _rb.constraints = RigidbodyConstraints2D.FreezeRotation;

                }
                else
                {
                    Destroy(GetComponent<Rigidbody2D>());
                    _rb = null;
                    _player = null;
                }
            }
        }

        if (_isMove)
        {
            _rb.velocity = _player.Direction * _player.Speed * _player.CarryingSpeedfactor;
        }
    }
}
*/