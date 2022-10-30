
public class TestMovableObject : MovableObject
{
    void Start()
    {
        IsMovable = true;
        IsDamagable = false;
    }


    void Update()
    {
        TryMove();
    }
}
