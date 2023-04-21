using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : GameUnit
{
    public Transform tF;
    public Vector3 pointWeaponStart;
    public int idWeapon;
    public float speed;
    public float maxSize;
    public Vector3 target;
    public Vector3 direction;
    public GameState gameState;
    private Character sourcecharacter;
    public Character SourceCharacter
    {
        get { return sourcecharacter; }
        set { sourcecharacter = value; }
    }

    private void Awake()
    {
        OnAwake();
    }

    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

    protected virtual void OnAwake()
    {
        tF = transform;
    }
    protected virtual void OnInit()
    {
    }
    protected virtual void OnUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {

    }
    protected virtual void IsTouch()
    {

    }
    protected virtual void IsTouchBox()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Character charac = Cache.GetCharacter(other);
        if (other.CompareTag(Constans.TAG_PLAYER) || other.CompareTag(Constans.TAG_ENEMY))
        {
            
            if (charac.idCharacter == idWeapon) return;
            LevelManager.Ins.listCharacter.Remove(charac);
            charac.Death();
            IsTouch();
            SoundsManager.Ins.PlaySoundsVolume(Constans.AUDIOSFXDIE);
            sourcecharacter.IncreaseScale();
            // if (sourcecharacter is Bot) return;
            if (sourcecharacter.CompareTag(Constans.TAG_ENEMY))
            {
                    LevelManager.Ins.SpawnerBot();
                    return;
            }
            //LevelManager.Ins.ResetGame();
            sourcecharacter.IncreseScore();
            LevelManager.Ins.WinGame();
        }
        Collider collider = other.GetComponent<Collider>();
        if (collider.CompareTag(Constans.TAG_COLLIDERBOX))
        {
            IsTouchBox();
        }
    }

    public Vector3 Direction(Vector3 dir)
    {
        return direction = dir;
    }
    public virtual void GetTarget()
    {

    }
    public virtual float GetBoundSize(Collider collider)
    {
        return maxSize;
    }

}
