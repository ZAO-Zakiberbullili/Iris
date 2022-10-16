using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovementBase _playerMovementBase;
    [SerializeField] private PlayerMovementBattle _playerMovementBattle;
    [SerializeField] private BattleActiveController _BattleActiveController;

    private MovementSystem _movementSystem;

    public GameObject[] Team;
    public PawnData[] TeamData;
    
    private Rigidbody2D[] _teamRB;
    private Animation[] _teamAnim;

    [SerializeField]
    private PlayerInput _input;

    private int _playerIndex = 0; 

    void Start()
    {
        _movementSystem = _playerMovementBase;

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
        if (_BattleActiveController.IsBattleActive)
        {
            _movementSystem = _playerMovementBattle;
        } else
        {
            _movementSystem = _playerMovementBase;
        }
 


        _playerIndex = (int) _input.Hero;

        AnimMove(_playerIndex);
        _movementSystem.MovePlayer(_playerIndex);

        if (!_BattleActiveController.IsBattleActive)
        for (int i = 0; i < 4; i++) {
            if (i != _playerIndex) {
                ((PlayerMovementBase) _movementSystem).FollowPlayer(i);
            }
        }

        /*for (int i = 0; i < 4; i++) {
            _teamAnim[i].Play("AnimLeft");
        }*/
    }

    void AnimMove(int playerIndex) 
    {
        

 //       Vector2 playerMove = new Vector2(_input.Move.x, _input.Move.y);

 //       _teamRB[playerIndex].velocity = playerMove * TeamData[playerIndex].Speed;
 
        if (_movementSystem.PlayerMove == Vector2.up) {
            _teamAnim[playerIndex].Play("AnimUp");
        } else if (_movementSystem.PlayerMove == Vector2.down) {
            _teamAnim[playerIndex].Play("AnimDown");
        } else if (_movementSystem.PlayerMove == Vector2.right) {
            _teamAnim[playerIndex].Play("AnimRight");
        } else if (_movementSystem.PlayerMove == Vector2.left) {
            _teamAnim[playerIndex].Play("AnimLeft");
        } 
    }

   /* void FollowPlayer(int playerIndex) 
    {
        // плагин
    } */
}
