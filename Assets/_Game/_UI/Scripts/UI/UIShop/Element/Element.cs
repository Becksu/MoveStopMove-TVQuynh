using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Element : MonoBehaviour
{
    public UIShop uiElemnt;
    public Image icon;
    public int idIcon;
    public int indexxTab;
    public int price;
    public GameObject prefab;
    public Material material;
    public bool isBuy = false;
    public void OnInit(int indextab,int index)
    {
        icon.sprite = UIManager.Ins.GetUI<UIShop>().data.InforUI[indextab].ListInforTab[index].icon;
        idIcon = UIManager.Ins.GetUI<UIShop>().data.InforUI[indextab].ListInforTab[index].idIcon;
        price = UIManager.Ins.GetUI<UIShop>().data.InforUI[indextab].ListInforTab[index].price;
        indexxTab = indextab;
        prefab = UIManager.Ins.GetUI<UIShop>().data.InforUI[indextab].ListInforTab[index].prefab;
        material = UIManager.Ins.GetUI<UIShop>().data.InforUI[indextab].ListInforTab[index].material;
    }
    public void ClickElement()
    {
       //uiElemnt.OnClickElement(price);
       uiElemnt.cureentElement = this;
       uiElemnt.currenTab = indexxTab;
       uiElemnt.currenId = idIcon;
       uiElemnt.HandleButton(indexxTab, idIcon,price);
    }
}
 