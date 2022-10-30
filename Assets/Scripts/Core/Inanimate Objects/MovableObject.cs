using UnityEngine;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _player = other.gameObject.GetComponent<Player>();

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
