public class TestMovableObject : MovableObject
{
    private void Start()
    {
        IsMovable = true;
    }


    private void Update()
    {
        TryMove();
    }
}
