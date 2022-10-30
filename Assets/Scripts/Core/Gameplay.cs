using System.Collections;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public static Gameplay GameManager;

    public GameObject playerPrefab;

    public PawnData[] PlayersData;

    public Player[] Players;

    public GameState State;

    public Hero hero = Hero.Hero0;

    public Vector2 direction;

    public void SwitchHero(Hero newHero)
    {
        for (int i = 0; i < Players.Length; i++)
        {
            Players[i].IsActive = false;
        }
        switch (newHero)
        {
            case Hero.Hero0:
                Players[0].IsActive = true;
                break;
            case Hero.Hero1:
                Players[1].IsActive = true;
                break;
            case Hero.Hero2:
                Players[2].IsActive = true;
                break;
            case Hero.Hero3:
                Players[3].IsActive = true;
                break;
        }
    }

    private void Start () 
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
        Players[0].IsActive = true;
    }

    private void Update ()
    {
        switch (State) {
            case GameState.Play:
                for (int i = 0; i < Players.Length; i++) {
                    if (Players[i].IsActive)
                    {
                        Players[i].IndependentMove(direction);
                    } 
                    else
                    {
                        Players[i].FollowMove();
                    }
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
    Hero0,
    Hero1,
    Hero2,
    Hero3,
}
