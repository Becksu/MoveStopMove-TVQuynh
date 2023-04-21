public enum WeaponType
{
    bullet,
    bomerang,
    sword
}
public enum ColorCharacter
{
    Blue,
    Red,
    Green,
    Yeallow,
    Pink,
    Black
}
public class Constans
{
    public const string ANIM_IDLE = "idle";
    public const string ANIM_RUN = "run";
    public const string ANIM_ATACK = "atack";
    public const string ANIM_DIE = "die";
    public const string ANIM_DANCE = "dance";
    public const string TAG_PLAYER = "Player";
    public const string TAG_ENEMY = "Enemy";
    public const string TAG_COLLIDERBOX = "BoxCollider";

    public const string AUDIOSFXDIE = "AudioSFXDie";
    public const string AUDIOSFXATACK = "AudioSFXAtack";
    public const string AUDIOSFXWIN = "AudioSFXWin";
    public const string AUDIOSFXLOSE = "AudioSFXLose";
    public static PoolType GetWeaponType(WeaponType type)
    {
        switch (type)
        {
            case WeaponType.bullet:
                return PoolType.Bullet;
            case WeaponType.sword:
                return PoolType.Sword;
            case WeaponType.bomerang:
                return PoolType.Bomerang;
            default:
                return PoolType.None;
        }
    }
}

