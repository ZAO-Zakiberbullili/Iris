using UnityEngine;

public class Player : Pawn
{
    private bool _isActive = false;
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
        RB.velocity = direction * Speed;

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
