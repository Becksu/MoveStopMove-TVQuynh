using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIGamePlay : UICanvas
{
    public TextMeshProUGUI textAlive;

    private void FixedUpdate()
    {
        OnFixUpdate();
    }
    public void OnFixUpdate()
    {
        textAlive.SetText(LevelManager.Ins.maxCharacterInGame.ToString());
    }
    public void OnClickSetting()
    {
        Time.timeScale = 0;
        CloseDirectly();
        UIManager.Ins.OpenUI<UIPause>();
    }
}
