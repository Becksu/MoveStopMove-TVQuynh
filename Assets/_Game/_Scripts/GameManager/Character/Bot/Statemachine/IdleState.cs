using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IStateMachine
{
    float timer;
    float randomTimer;
    public void OnEnter(Bot bot)
    {
        timer = 0;
        randomTimer = Random.Range(1f, 3f);
        bot.StopMove();
    }

    public void OnExcute(Bot bot)
    {
        timer += Time.deltaTime;
        if (timer > randomTimer)
        {
            bot.ChangState(new PatrolState());
        }
    }

    public void OnExit(Bot bot)
    {

    }
}
