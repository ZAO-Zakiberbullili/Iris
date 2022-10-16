using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
