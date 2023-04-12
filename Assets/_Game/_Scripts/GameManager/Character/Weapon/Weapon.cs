using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : GameUnit
{
    public Transform tF;
    public int idWeapon;
    public float speed;
    public float maxSize;
    public Vector3 target;
    public Vector3 direction;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constans.TAG_PLAYER) || other.CompareTag(Constans.TAG_ENEMY))
        {
            Character otherId = other.GetComponent<Character>();
            if (otherId.idCharacter == idWeapon) return;
            IsTouch();
            otherId.Death(); 
            sourcecharacter.IncreaseScale();
            // if (sourcecharacter is Bot) return;
            if (sourcecharacter.CompareTag(Constans.TAG_ENEMY))
            {
                LevelManager.Ins.SpawnerBot();
                return;
            }

            sourcecharacter.IncreseScore();
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(Constans.TAG_PLAYER) || other.CompareTag(Constans.TAG_ENEMY))
        {
            if (gameObject.activeInHierarchy)
            {
                Character otherId = other.GetComponent<Character>();
                if (otherId.idCharacter == idWeapon) return;
                IsTouch();
                otherId.Death();
                sourcecharacter.IncreaseScale();
                // if (sourcecharacter is Bot) return;
                if (sourcecharacter.CompareTag(Constans.TAG_ENEMY))
                {
                    LevelManager.Ins.SpawnerBot();
                    return;
                }

                sourcecharacter.IncreseScore();
            }
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
