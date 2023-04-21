using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIWeapon : UICanvas
{



    public TextMeshProUGUI text;
    private void OnEnable()
    {
        text.SetText(LevelManager.Ins.coint.ToString());
    }
    private void Start()
    {
        text.SetText(LevelManager.Ins.coint.ToString());
    }
    public void ClickToMenu()
    {
        CloseDirectly();
        UIManager.Ins.OpenUI<UIMenu>();
    }
    public void ClickRight()
    {

    }
    public void ClickLeft()
    {

    }
    public void ClickBuy()
    {

    }
}
