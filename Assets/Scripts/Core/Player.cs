using UnityEngine;

public class Player : Pawn
{
    public void Move(Vector2 direction)
    {
        RB.velocity = direction * Speed;

        switch (direction) {
            case Vector2 v when v.Equals(Vector2.right):
                animator.Play("Right", 0, 0f);
                break;
            case Vector2 v when v.Equals(Vector2.left):
                animator.Play("Left", 0, 0f);
                break;
            case Vector2 v when v.Equals(Vector2.up):
                animator.Play("Up", 0, 0f);
                break;
            case Vector2 v when v.Equals(Vector2.down):
                animator.Play("Down", 0, 0f);
                break;
        }
    }

    public void Follow()
    {

    }

    void MoveToNearbyTile()
    {

    }
}
