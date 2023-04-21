using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName ="Data",menuName ="Data/DataUI",order =1)]
public class DataUI : ScriptableObject
{
    public List<InforTab> InforUI;
}
[System.Serializable]
public class InforTab
{
    public List<InfoElement> ListInforTab;
}
[System.Serializable]
public class InfoElement
{
    public int idIcon;
    public Sprite icon;
    public int price;
    public GameObject prefab;
    public Material material;

}
