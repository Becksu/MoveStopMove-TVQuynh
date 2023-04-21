using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIWin : UICanvas
{
    public TextMeshProUGUI text;
    public void OnClickBack()
    {
        UIManager.Ins.CloseUI<UIWin>();
        UIManager.Ins.OpenUI<UIMenu>();
        LevelManager.Ins.ResetGame();
    }
}
