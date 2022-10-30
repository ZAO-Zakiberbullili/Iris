using UnityEngine;

public class Pawn : MonoBehaviour
{
    int Hp, MaxHp;
    int Mp, MaxMp;
    protected int Speed, TilesPerTurn;

    protected Rigidbody2D RB;
    
    SpriteRenderer spriteRenderer;
    protected Animator animator;

    public void LoadHpData(int hp, int maxHp)
    {
        Hp = hp;
        MaxHp = maxHp;
    }

    public void LoadMpData(int mp, int maxMp)
    {
        Mp = mp;
        MaxMp = maxMp;
    }

    public void LoadMoveData(int speed, int tilesPerTurn)
    {
        Speed = speed;
        TilesPerTurn = tilesPerTurn;
    }

    public void AddHp(int hp)
    {
        int tempHp = Hp + hp;
        if (tempHp > MaxHp) {
            RestoreHp();
        } else Hp = tempHp;
    }

    public void AddMp(int mp)
    {
        int tempMp = Mp + mp;
        if (tempMp > MaxMp) {
            RestoreHp();
        } else Mp = tempMp;
    }

    public void RestoreHp() {
        Hp = MaxHp;
    }

    public void RestoreMp() {
        Mp = MaxMp;
    }

    public void AddDamage(int damage) {
        int tempHp = Hp - damage;
        if (tempHp < 0) {
            Destroy(gameObject);
          } else Hp = tempHp;
    }

    public void ConsumeMana(int manaConsumed) {
        int tempMp = Mp - manaConsumed;
        if (tempMp < 0) {
            Destroy(gameObject);
          } else Mp = tempMp;
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
