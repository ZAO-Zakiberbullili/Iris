using UnityEngine;

[CreateAssetMenu(fileName = "PawnData", menuName = "PawnData", order = 1)]
public class PawnData : ScriptableObject
{
    public string Name;
    public int X, Y;
    public int Hp, MaxHp;
    public int Mp, MaxMp;
    public int Speed, TilesPerTurn;
    public Sprite sprite;
    public RuntimeAnimatorController Anim;
}
