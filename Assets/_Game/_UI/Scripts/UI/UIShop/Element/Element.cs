using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour
{
    public Image icon;
    public int idIcon;
    public int indexTab;

    public void OnInit(int indextab,int index)
    {
        icon.sprite = UIManager.Ins.GetUI<UIShop>().data.InforUI[indextab].ListInforTab[index].icon;
        idIcon = UIManager.Ins.GetUI<UIShop>().data.InforUI[indextab].ListInforTab[index].idIcon;
    }

}
