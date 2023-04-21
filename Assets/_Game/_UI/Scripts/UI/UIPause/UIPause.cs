using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPause : UICanvas
{
    public void ClickContinue()
    {
        Time.timeScale = 1;
        CloseDirectly();
        UIManager.Ins.OpenUI<UIGamePlay>();
    }
    public void ClickHome()
    {
        Time.timeScale = 1;
        CloseDirectly();
        UIManager.Ins.OpenUI<UIMenu>();
        LevelManager.Ins.ResetGame();
    }
}
