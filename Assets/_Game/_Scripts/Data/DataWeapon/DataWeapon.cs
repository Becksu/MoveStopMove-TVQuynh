using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="Data",menuName ="Data/DataWeapon")] 
public class DataWeapon : ScriptableObject
{
    public List<InfoElement> listWeapon;
}
[SerializeField]
public class InfoWeapon
{
    public string name;
    public RawImage image;
}
