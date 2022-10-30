using UnityEngine;

public class Player : Pawn
{
    [SerializeField] private float _CarryingSpeedfactor;
    private bool _isActive = false;
    private bool _isMoveObject = false;
    
    public float CarryingSpeedfactor
    {
        get
        {
            return _CarryingSpeedfactor;
        }
    }

    public bool IsMoveObject{
        set
        {
            _isMoveObject = value;
        }
    }
    public bool IsActive { 
        get { 
            return _isActive; 
        } 
        set { 
            _isActive = value; 
        } 
    }


    public void IndependentMove(Vector2 direction)
    {
        RB.velocity = direction * Speed * (_isMoveObject ? _CarryingSpeedfactor : 1);
        Direction = direction;
        switch (direction) {
            case Vector2 v when v.Equals(Vector2.right):
                Animator.Play("Right", 0, 0f);
                break;
            case Vector2 v when v.Equals(Vector2.left):
                Animator.Play("Left", 0, 0f);
                break;
            case Vector2 v when v.Equals(Vector2.up):
                Animator.Play("Up", 0, 0f);
                break;
            case Vector2 v when v.Equals(Vector2.down):
                Animator.Play("Down", 0, 0f);
                break;
        }
    }

    public void FollowMove()
    {

    }

    void MoveToNearbyTile()
    {

    }
}
