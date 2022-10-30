using System.Collections;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public static Gameplay GameManager;

    public GameObject playerPrefab;

    public PawnData[] PlayersData;

    public Player[] Players;

    public GameState State;

    public Hero hero = Hero.Hero1;

    public Vector2 direction;

    void Start () 
    {
        GameManager = this;

        int i = 0;
        foreach (PawnData playerData in PlayersData) {
            GameObject newPawn = Instantiate(playerPrefab, new Vector3(playerData.X, playerData.Y, 0f), Quaternion.identity) as GameObject;

            Player player = newPawn.GetComponent<Player>();
            Players[i] = player;
            i++;

            player.LoadHpData(playerData.Hp, playerData.MaxHp);
            player.LoadMpData(playerData.Mp, playerData.MaxMp);
            player.LoadMoveData(playerData.Speed, playerData.TilesPerTurn);
            player.LoadSprite(playerData.sprite);
            player.LoadAnimations(playerData.Anim);
        }

        State = GameState.Play;
    }

    void Update ()
    {
        switch (State) {
            case GameState.Play:
                for (int i = 0; i < 4; i++) {
                    if ((int)hero == i) {
                        Players[(int)hero].Move(direction);
                    } else Players[i].Follow();
                }
                break;
            case GameState.Fight:
                break;
        }
    }
}

public enum GameState {
    Play,
    Fight,
}

public enum Hero {
    Hero1,
    Hero2,
    Hero3,
    Hero4,
}
