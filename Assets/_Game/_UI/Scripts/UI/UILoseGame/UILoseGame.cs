using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UILoseGame : UICanvas
{
    public TextMeshProUGUI text;
    public void OnClickBack()
    {
        UIManager.Ins.CloseUI<UILoseGame>();
        UIManager.Ins.OpenUI<UIMenu>();
        LevelManager.Ins.ResetGame();
    }
    public void OnClickADS()
    {
        LevelManager.Ins.SpawnerPlayer();
        UIManager.Ins.CloseUI<UILoseGame>();
        UIManager.Ins.OpenUI<UIGamePlay>();
    }
}
