using UnityEngine;

public class Pawn : MonoBehaviour
{
    private int _hp, _maxHp;
    private int _mp, _maxMp; 
    protected int Speed, TilesPerTurn;
    private SpriteRenderer _spriteRenderer;


    protected Rigidbody2D RB;
    protected Animator Animator;

    public void LoadHpData(int hp, int maxHp)
    {
        _hp = hp;
        _maxHp = maxHp;
    }

    public void LoadMpData(int mp, int maxMp)
    {
        _mp = mp;
        _maxMp = maxMp;
    }

    public void LoadMoveData(int speed, int tilesPerTurn)
    {
        Speed = speed;
        TilesPerTurn = tilesPerTurn;
    }

    public void AddHp(int hp)
    {
        int tempHp = _hp + hp;
        if (tempHp > _maxHp) {
            RestoreHp();
        } else _hp = tempHp;
    }

    public void AddMp(int mp)
    {
        int tempMp = _mp + mp;
        if (tempMp > _maxMp) {
            RestoreHp();
        } else _mp = tempMp;
    }

    public void RestoreHp() {
        _hp = _maxHp;
    }

    public void RestoreMp() {
        _mp = _maxMp;
    }

    public void AddDamage(int damage) {
        int tempHp = _hp - damage;
        if (tempHp < 0) {
            Destroy(gameObject);
          } else _hp = tempHp;
    }

    public void ConsumeMana(int manaConsumed) {
        int tempMp = _mp - manaConsumed;
        if (tempMp < 0) {
            Destroy(gameObject);
          } else _mp = tempMp;
    }

    public void LoadSprite(Sprite sprite)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }

    public void LoadAnimations(RuntimeAnimatorController anim)
    {
        Animator animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = anim;
    }

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }
}
