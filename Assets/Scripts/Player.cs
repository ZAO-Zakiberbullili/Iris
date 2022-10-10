using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] Team;
    public PawnData[] TeamData;

    private Rigidbody2D[] _teamRB;
    private Animation[] _teamAnim;

    [SerializeField]
    private PlayerInput _input;

    private int _playerIndex = 0; 

    void Start()
    {
        _teamRB = new Rigidbody2D[4];
        _teamAnim = new Animation[4];

        for (int i = 0; i < 4; i++) {
            _teamRB[i] = Team[i].AddComponent<Rigidbody2D>();
            _teamAnim[i] = Team[i].AddComponent<Animation>();
            // todo: change for standing anim
            _teamAnim[i].AddClip(TeamData[i].AnimUp, "AnimUp");
            _teamAnim[i].AddClip(TeamData[i].AnimDown, "AnimDown");
            _teamAnim[i].AddClip(TeamData[i].AnimRight, "AnimRight");
            _teamAnim[i].AddClip(TeamData[i].AnimLeft, "AnimLeft");
        }
    }

    void Update()
    {
        _playerIndex = (int) _input.Hero;

        Move(_playerIndex);
        for (int i = 0; i < 4; i++) {
            if (i != _playerIndex) {
                FollowPlayer(i);
            }
        }

        /*for (int i = 0; i < 4; i++) {
            _teamAnim[i].Play("AnimLeft");
        }*/
    }

    void Move(int playerIndex) 
    {
        Vector2 playerMove = new Vector2(_input.Move.x, _input.Move.y);

        _teamRB[playerIndex].velocity = playerMove * TeamData[playerIndex].Speed;

        if (playerMove == Vector2.up) {
            _teamAnim[playerIndex].Play("AnimUp");
        } else if (playerMove == Vector2.down) {
            _teamAnim[playerIndex].Play("AnimDown");
        } else if (playerMove == Vector2.right) {
            _teamAnim[playerIndex].Play("AnimRight");
        } else if (playerMove == Vector2.left) {
            _teamAnim[playerIndex].Play("AnimLeft");
        }
    }

    void FollowPlayer(int playerIndex) 
    {
        // плагин
    }
}
