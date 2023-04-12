using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public static int idCharacter;
    public int maxCharacterInScreen;
    public int maxCharacterInGame;
    public bool isStartGame;
    public Player player;

    private void Awake()
    {
        isStartGame = false;
        idCharacter = 0;
        maxCharacterInScreen = 0;
        maxCharacterInGame = 99;

    }
    private void Start()
    {
        SpawnerPlayer();
        InvokeRepeating(nameof(SpawnerBot), 0, 5f);
    }
    public void SpawnerPlayer()
    {
        player = SimplePool.Spawn<Player>(PoolType.Player);
        player.transform.position = Vector3.zero;
        player.idCharacter = idCharacter;
        idCharacter++;
        maxCharacterInScreen++;
    }
    public void SpawnerBot()
    {
        if (maxCharacterInGame <= 0)
        {
            CancelInvoke(nameof(SpawnerBot));
            return;
        }
        while (maxCharacterInScreen < 9)
        {
            Bot bot = SimplePool.Spawn<Bot>(PoolType.Bot);
            bot.ChangAnim(Constans.ANIM_IDLE);
            Vector3 pos = new Vector3(Random.Range(-24f, 24f), 0, Random.Range(-23f, 23f));
            bot.transform.position = pos;
            bot.idCharacter = idCharacter;
            idCharacter++;
            maxCharacterInScreen++;
            maxCharacterInGame--;
            bot.ResetAtribute();
        }
    }
    public void WinGame()
    {
        if (maxCharacterInGame < 1 && maxCharacterInScreen == 1)
        {
            Debug.Log("win");
        }
    }
}
