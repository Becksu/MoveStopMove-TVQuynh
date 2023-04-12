using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    private IStateMachine stateMachine;
    public NavMeshAgent meshAgent;

    private void OnDisable()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        gameObject.SetActive(true);
    }
    protected override void OnInit()
    {
        base.OnInit();
        ChangState(new IdleState());
    }
    protected override void OnUpdate()
    {
        base.OnUpdate();
        ExcuteState();
    }
    public void ChangState(IStateMachine state)
    {
        stateMachine?.OnExit(this);
        stateMachine = state;
        stateMachine?.OnEnter(this);
    }
    protected void ExcuteState()
    {
        if (!LevelManager.Ins.isStartGame) return;
        if (isDie) return;
        stateMachine?.OnExcute(this);
    }

    public override void ResetAtribute()
    {
        base.ResetAtribute();
        meshAgent.enabled = true;
    }
    public void Move(Vector3 target)
    {
        if (isDie) return;
        ChangAnim(Constans.ANIM_RUN);
        meshAgent.SetDestination(target);
        tF.rotation = Quaternion.LookRotation(target);
        meshAgent.isStopped = false;
        if (!attacker.GetCharacterRange()) return;
        ChangState(new AtackState());
    }
    public override void Atack()
    {
        base.Atack();
        meshAgent.isStopped = true;
    }
    public void StopMove()
    {
        meshAgent.isStopped = true;
        ChangAnim(Constans.ANIM_IDLE);
        if (!attacker.GetCharacterRange()) return;
        ChangState(new AtackState());
    } 
    public override void Death()
    {
        base.Death();
        meshAgent.isStopped = true;
        meshAgent.enabled = false;
        meshAgent.transform.rotation = Quaternion.identity;
    }
}
