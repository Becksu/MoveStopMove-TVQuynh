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
    }

    public void OnExcute(Bot bot)
    {
        timer += Time.deltaTime;
        if (timer<randomTimer)
        {
            bot.Move(target);
        }

        else
        {
            bot.ChangState(new IdleState());
        }
    }

    public void OnExit(Bot bot)
    {

    }
}
