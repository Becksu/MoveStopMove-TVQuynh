using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMenu: UICanvas
{
    public TextMeshProUGUI text;
    void Start()
    {
        text.SetText(LevelManager.Ins.coint.ToString());
    }
    private void OnEnable()
    {
        text.SetText(LevelManager.Ins.coint.ToString());
    }

    public void OnClickShop()
    {
        CloseDirectly();
        UIManager.Ins.OpenUI<UIShop>();
        LevelManager.Ins.player.ChangAnim(Constans.ANIM_DANCE);
    }
    public void OnClickPlay()
    {
        LevelManager.Ins.isStartGame = true;
        CloseDirectly();
        UIManager.Ins.OpenUI<UIGamePlay>();
    }
    public void OnClickWeapon()
    {
        UIManager.Ins.OpenUI<UIWeapon>();
        CloseDirectly();
    }
    public void AddScore()
    {
        LevelManager.Ins.coint += 500;
        text.SetText(LevelManager.Ins.coint.ToString());
        LevelManager.Ins.gameSave.dataGame.scoreCoint = LevelManager.Ins.coint;
        LevelManager.Ins.gameSave.SaveGame();
    }
    public void RemoveScore()
    {
        LevelManager.Ins.coint -= 500;
        text.SetText(LevelManager.Ins.coint.ToString());
        LevelManager.Ins.gameSave.dataGame.scoreCoint = LevelManager.Ins.coint;
        LevelManager.Ins.gameSave.SaveGame();
    }
}
