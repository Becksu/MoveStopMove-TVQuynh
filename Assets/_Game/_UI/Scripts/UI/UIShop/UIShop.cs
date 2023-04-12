using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : UICanvas
{
    public DataUI data;
    public Element element;
    public RectTransform content;
    public List<Button> btns;
    List<Element> elements = new List<Element>();
    private void Start()
    {
        for (int i = 0; i < btns.Count; i++)
        {
            int index = i;
            btns[index].onClick.AddListener(() =>
            {
                GetElement(index);
            });
        }
        GetElement(0);
    }

    public void GetElement(int index)
    {
        if (elements.Count < 1)
        {
            for (int i = 0; i < data.InforUI[index].ListInforTab.Count; i++)
            {
                Element ele = Instantiate(element, content);
                ele.OnInit(index, i);
                elements.Add(ele);
            }
        }
        int curerenIndex = elements.Count;
        int targetIndex = data.InforUI[index].ListInforTab.Count;
        if (curerenIndex < targetIndex)
        {
            int add = targetIndex - curerenIndex;
            for (int i = 0; i < add; i++)
            {
                Element ele = Instantiate(element, content);
                elements.Add(ele);
            }
            for(int i = 0; i < targetIndex; i++)
            {
                elements[i].OnInit(index, i);
            }
        }
        else
        {
            int remove = curerenIndex - targetIndex;
            for (int i = 0; i < remove; i++)
            {
                //elements[curerenIndex-1].gameObject.SetActive(false);
                Destroy(elements[curerenIndex - 1].gameObject);
                elements.RemoveAt(curerenIndex - 1);
                curerenIndex--;
            }
            for (int j = 0; j < targetIndex; j++)
            {
                elements[j].OnInit(index, j);
            }
        }
    }
    //public void GetElement(int index)
    //{
    //    if (elements.Count < 1)
    //    {
    //        for (int i = 0; i < data.InforUI[index].ListInforTab.Count; i++)
    //        {
    //            Element ele = Instantiate(element, content);
    //            ele.OnInit(index, i);
    //            elements.Add(ele);
    //        }
    //    }
    //    int count = elements.Count;

    //    for (int i = 0; i < data.InforUI[index].ListInforTab.Count; i++)
    //    {
    //        //////count = count - data.InforUI[index].ListInforTab.Count;
    //        if (count > data.InforUI[index].ListInforTab.Count)
    //        {

    //            elements[i].OnInit(index, i);
    //        }
    //        else
    //        {
    //            elements[i].OnInit(index, i);
    //        }
    //    }
    //}

    public void OnClickBackToMenu()
    {
        //Close();
        //UIManager.Ins.
    }

}
