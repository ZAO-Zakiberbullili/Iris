using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 Move { get; private set; }

    public Heroes Hero = Heroes.Hero1; 

    public void OnMove(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>();
    }

    public void OnSwitchHero1(InputAction.CallbackContext context) 
    {
        if (context.started) {
            Hero = Heroes.Hero1;
        }
    }

    public void OnSwitchHero2(InputAction.CallbackContext context) 
    {
        if (context.started) {
            Hero = Heroes.Hero2;
        }
    }

    public void OnSwitchHero3(InputAction.CallbackContext context) 
    {
        if (context.started) {
            Hero = Heroes.Hero3;
        }
    }

    public void OnSwitchHero4(InputAction.CallbackContext context) 
    {
        if (context.started) {
            Hero = Heroes.Hero4;
        }
    }
}

public enum Heroes {
    Hero1,
    Hero2,
    Hero3,
    Hero4,
}
