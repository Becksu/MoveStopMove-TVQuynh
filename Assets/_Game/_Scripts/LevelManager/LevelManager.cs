using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public static int idCharacter;
    public int coint;
    public int maxCharacterInScreen;
    public int maxCharacterInGame;
    public bool isStartGame;
    public bool isWin;
    public int scorePlayer;
    public Player player;
    public CameraFollow camera;
    public List<Character> listCharacter = new List<Character>();
   // public DataGame dataGame = new DataGame();
    public GameSave gameSave = new GameSave();
    public GameLoad gameLoad = new GameLoad();

    private void Awake()
    {
       // gameSave.SaveGame();
        gameLoad.LoadGame();
        isStartGame = false;
        isWin = false;
        idCharacter = 0;
        maxCharacterInScreen = 0;
        maxCharacterInGame = 99;
        coint = gameSave.dataGame.scoreCoint;
    }
    private void Start()
    {
        UIManager.Ins.OpenUI<UIMenu>();
        SpawnerPlayer();
        InvokeRepeating(nameof(SpawnerBot), 0, 5f);
    }
    public void SpawnerPlayer()
    {
        Player play = SimplePool.Spawn<Player>(PoolType.Player);
        player = play;
        play.ResetAtribute();
        player.transform.position = Vector3.zero;
        player.idCharacter = idCharacter;
        idCharacter = 0;
        idCharacter++;
        maxCharacterInScreen++;
        listCharacter.Add(player);
    }
    public void SpawnerBot()
    {
        if (maxCharacterInGame <= 0)
        {
            CancelInvoke(nameof(SpawnerBot));
            return;
        }
        while (maxCharacterInScreen < 10&&maxCharacterInGame>0)
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
            listCharacter.Add(bot);
        }
    }
    public void WinGame()
    {
        if (listCharacter.Count<2&&maxCharacterInGame<1)
        {
            if (listCharacter.Contains(player))
            {
                isWin = true;
                StartCoroutine(CloseUIWin());
            }
        }
    }
    public void LoseGame()
    {
        if (!isWin)
        {
            if (player.isDie)
            {
                StartCoroutine(CloseUIInDeath());
            }
        }
    }

    public void ResetGame()
    {
        isStartGame = false;
        SimplePool.CollectAll();
        listCharacter.Clear();
        idCharacter = 0;
        maxCharacterInScreen = 0;
        maxCharacterInGame = 99;
        camera.transform.position = camera.starPos.position;
        camera.transform.rotation = camera.starPos.rotation;
        camera.isCamera = false;
        SpawnerPlayer();
        SpawnerBot();
    }
    public IEnumerator CloseUIInDeath()
    {
        yield return new WaitForSeconds(1.5f);
        SoundsManager.Ins.PlaySoundsVolume(Constans.AUDIOSFXLOSE);
        UIManager.Ins.CloseUI<UIGamePlay>();
        UIManager.Ins.OpenUI<UILoseGame>();
        UIManager.Ins.GetUI<UILoseGame>().text.SetText(scorePlayer.ToString());
        coint += scorePlayer;
        gameSave.dataGame.scoreCoint = coint;
        gameSave.SaveGame();

    }
    public IEnumerator CloseUIWin()
    {
        yield return new WaitForSeconds(1.5f);
        SoundsManager.Ins.PlaySoundsVolume(Constans.AUDIOSFXWIN);
        UIManager.Ins.CloseUI<UIGamePlay>();
        UIManager.Ins.OpenUI<UIWin>();
        UIManager.Ins.GetUI<UIWin>().text.SetText(scorePlayer.ToString());
        yield return new WaitForSeconds(0.5f);
        player.DespawnerCharacter();
        coint += scorePlayer;
        gameSave.dataGame.scoreCoint = coint;
        gameSave.SaveGame();

    }
}
