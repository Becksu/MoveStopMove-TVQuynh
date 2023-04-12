using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : GameUnit
{
    public Animator animator;
    public Attacker attacker;
    public Transform tF;
    public Transform startPointWeapon;
    public ParticleSystem hitVFX;
    public Transform hitVFXPoint;
    public WeaponType currentWeapon;
    public Vector3 distanceAtackPoint;
    private string currentAnim;
    public int idCharacter;
    public bool isDie;
    public int score;
    private void Awake()
    {
        OnAwake();
    }
    private void Start()
    {
        OnInit();
    }
    private void Update()
    {
        OnUpdate();
    }
    //private void FixedUpdate()
    //{
    //    OnFixUpdate();
    //}
    protected void OnAwake()
    {
        tF = transform;
        isDie = false;
    }
    protected virtual void OnInit()
    {
        distanceAtackPoint = startPointWeapon.position - Vector3.zero;
    }
    protected virtual void OnUpdate()
    {

    }
    protected virtual void OnFixUpdate()
    {

    }
    public void ChangAnim(string anim)
    {
        if(currentAnim!= anim)
        {
            animator.ResetTrigger(currentAnim);
            currentAnim = anim;
            animator.SetTrigger(currentAnim);
        }
    }
    private Character GetCharacter()
    {
        Character character = attacker.GetCharacterRange();
        if (character == null) return null;
        return character;
    }
    public virtual void Atack()
    {
        if (isDie) return;
        ChangAnim(Constans.ANIM_ATACK);
        Vector3 direction = GetCharacter().transform.position - tF.position;
        tF.rotation = Quaternion.LookRotation(direction);
        Weapon weapon = SimplePool.Spawn<Weapon>(Constans.GetWeaponType(currentWeapon));
        weapon.idWeapon = idCharacter; 
        weapon.SourceCharacter = this;
        weapon.transform.position = new Vector3(startPointWeapon.position.x, distanceAtackPoint.y, startPointWeapon.position.z);
        weapon.Direction(direction);
        weapon.GetBoundSize(attacker.GetComponent<Collider>());
        weapon.GetTarget();
    }
    
    public virtual void ResetAtribute()
    {
        isDie = false;
        tF.GetComponent<Rigidbody>().isKinematic = false;
        tF.localScale = new Vector3(1, 1, 1);
        tF.GetComponent<CapsuleCollider>().center = Vector3.zero;
        attacker.GetComponent<SphereCollider>().center = Vector3.zero;
        //attacker.GetComponent<SphereCollider>().transform.position
        if (tF.CompareTag(Constans.TAG_ENEMY)) return;
        score = 0;
    }
    public virtual void Death()
    {
        isDie = true;
        LevelManager.Ins.maxCharacterInScreen -= 1;
        tF.GetComponent<Rigidbody>().isKinematic = true;
        tF.GetComponent<CapsuleCollider>().center += new Vector3(0, 20f, 0);
        attacker.GetComponent<SphereCollider>().center += new Vector3(0, 50f, 0);
        Invoke(nameof(DespawnerCharacter), 2.5f);
        Vector3 worldpos = hitVFXPoint.TransformPoint(Vector3.zero);
        ParticlePool.Play(hitVFX,worldpos,Quaternion.identity);
        Invoke(nameof(DespawnVFX), 2f);
        ChangAnim(Constans.ANIM_DIE);
    }
    public void IncreaseScale()
    {
        tF.localScale *= 1.2f;
    }
    public void IncreseScore()
    {
        score += 1;
    }

    public void DespawnVFX()
    {
        ParticlePool.Release(hitVFX);
    }
    public void DespawnerCharacter()
    {
        SimplePool.Despawn(this);
    }
}
