using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu: UICanvas
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnClickShop()
    {
        CloseDirectly();
        UIManager.Ins.OpenUI<UIShop>();
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
}
