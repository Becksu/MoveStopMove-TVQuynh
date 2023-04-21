using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackState : IStateMachine
{
    float timer;
    public void OnEnter(Bot bot)
    {
        timer = 0;
        bot.Atack();
    }

    public void OnExcute(Bot bot)
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            bot.ChangState(new PatrolState());
        }
    }

    public void OnExit(Bot bot)
    {

    }
}
