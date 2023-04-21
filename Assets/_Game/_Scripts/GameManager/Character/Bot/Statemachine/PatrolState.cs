using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IStateMachine
{
    float timer;
    float randomTimer;
    Vector3 target;
    public void OnEnter(Bot bot)
    {
        timer = 0;

        randomTimer = Random.Range(2f, 4f);
        target = new Vector3(Random.Range(-24f, 24f), 0, Random.Range(-24f, 24f));
        bot.Move(target);
    }

    public void OnExcute(Bot bot)
    {
        timer += Time.deltaTime;
        if (bot.GetCharacter()&&timer>2.5f)
        {
            bot.ChangState(new AtackState());
        }
        if(timer > randomTimer||Vector3.Distance(bot.tF.position,target)<0.1f)
        {
            bot.ChangState(new IdleState());
        }
    }

    public void OnExit(Bot bot)
    {

    }
}
