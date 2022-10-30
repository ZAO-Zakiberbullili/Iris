using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public void OnMove(InputAction.CallbackContext context)
    {
        Gameplay.GameManager.direction = context.ReadValue<Vector2>();
    }

    public void OnSwitchHero0(InputAction.CallbackContext context) 
    {
        if (context.started) {
            //    Gameplay.GameManager.hero = Hero.Hero1;
            Gameplay.GameManager.SwitchHero(Hero.Hero0);
        }
    }

    public void OnSwitchHero1(InputAction.CallbackContext context) 
    {
        if (context.started) {
            //  Gameplay.GameManager.hero = Hero.Hero2;
            Gameplay.GameManager.SwitchHero(Hero.Hero1);
        }
    }

    public void OnSwitchHero2(InputAction.CallbackContext context) 
    {
        if (context.started) {
           // Gameplay.GameManager.hero = Hero.Hero3;
            Gameplay.GameManager.SwitchHero(Hero.Hero2);
        }
    }

    public void OnSwitchHero3(InputAction.CallbackContext context) 
    {
        if (context.started) {
            // Gameplay.GameManager.hero = Hero.Hero4;
            Gameplay.GameManager.SwitchHero(Hero.Hero3);
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
