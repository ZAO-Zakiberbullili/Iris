public class TestMovableObject : MovableObject
{
    private void Start()
    {
        IsMovable = true;
        IsDamagable = false;
    }


    private void Update()
    {
        TryMove();
    }
}
