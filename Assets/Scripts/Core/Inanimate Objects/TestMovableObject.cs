public class TestMovableObject : MovableObject
{
    private void Start()
    {
        base.Start();
        IsMovable = true;
    }


    private void Update()
    {
        TryMove();
    }
}
