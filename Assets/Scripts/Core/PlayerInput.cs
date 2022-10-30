using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public void OnMove(InputAction.CallbackContext context)
    {
        Gameplay.GameManager.direction = context.ReadValue<Vector2>();
    }

    public void OnSwitchHero1(InputAction.CallbackContext context) 
    {
        if (context.started) {
            Gameplay.GameManager.hero = Hero.Hero1;
        }
    }

    public void OnSwitchHero2(InputAction.CallbackContext context) 
    {
        if (context.started) {
            Gameplay.GameManager.hero = Hero.Hero2;
        }
    }

    public void OnSwitchHero3(InputAction.CallbackContext context) 
    {
        if (context.started) {
            Gameplay.GameManager.hero = Hero.Hero3;
        }
    }

    public void OnSwitchHero4(InputAction.CallbackContext context) 
    {
        if (context.started) {
            Gameplay.GameManager.hero = Hero.Hero4;
        }
    }

    public void OnQuit(InputAction.CallbackContext context)
    {
        if (context.started) {
            SaveLoad.Save();
            Application.Quit();
        }
    }
}
