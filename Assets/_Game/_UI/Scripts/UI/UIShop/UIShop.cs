using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIShop : UICanvas
{
    public DataUI data;
    public Element element;
    public Element cureentElement;
    public RectTransform content;
    public List<Button> btns;
    public GameObject buttonElementBuy;
    public GameObject buttonElementEquiment;
    public GameObject buttonElementSellect;
    public TextMeshProUGUI textPrice;
    public TextMeshProUGUI textCoint;
    public int currenId;
    public int currenTab;
    public bool back = false;
    List<Element> elements = new List<Element>();
    GameObject Hair;
    GameObject Sheld;
    private void OnEnable()
    {
        textCoint.SetText(LevelManager.Ins.coint.ToString());
    }
    private void Start()
    {
        textCoint.SetText(LevelManager.Ins.coint.ToString());
        element.uiElemnt = this;
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
            elements[0].ClickElement();
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
            for (int i = 0; i < targetIndex; i++)
            {
                elements[i].OnInit(index, i);
            }
            elements[0].ClickElement();
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
            elements[0].ClickElement();
        }
    }
    public void OnClickBackToMenu()
    {
        CloseDirectly();
        UIManager.Ins.OpenUI<UIMenu>();
        LevelManager.Ins.player.ChangAnim(Constans.ANIM_IDLE);

        if (currenId != LevelManager.Ins.gameSave.dataGame.currentHair && LevelManager.Ins.gameSave.dataGame.purchasedHair.Count != 0)
        {
            if (Hair != null)
            {
                Destroy(Hair.gameObject);
                Hair = Instantiate(data.InforUI[0].ListInforTab[LevelManager.Ins.gameSave.dataGame.currentHair].prefab, LevelManager.Ins.player.PointHair.transform);
                LevelManager.Ins.gameSave.SaveGame();
            }
        }
        if (LevelManager.Ins.gameSave.dataGame.purchasedHair.Count == 0)
        {
            Destroy(Hair.gameObject);
        }
        if (currenId != LevelManager.Ins.gameSave.dataGame.currenShort && LevelManager.Ins.gameSave.dataGame.purchasedHair.Count != 0)
        {
            LevelManager.Ins.player.meshRenderShort.material = data.InforUI[1].ListInforTab[LevelManager.Ins.gameSave.dataGame.currenShort].material;
            LevelManager.Ins.gameSave.SaveGame();
        }
        if (LevelManager.Ins.gameSave.dataGame.purchasedShort.Count == 0)
        {
            LevelManager.Ins.player.meshRenderShort.material = LevelManager.Ins.player.meshRenderShort.material;
        }
        if (currenId != LevelManager.Ins.gameSave.dataGame.currentSheiel && LevelManager.Ins.gameSave.dataGame.purchasedHair.Count != 0)
        {
            if (Sheld != null)
            {
                Destroy(Sheld.gameObject);
                Sheld = Instantiate(data.InforUI[2].ListInforTab[LevelManager.Ins.gameSave.dataGame.currentSheiel].prefab, LevelManager.Ins.player.PointSheld.transform);
                LevelManager.Ins.gameSave.SaveGame();
            }
        }
        if (LevelManager.Ins.gameSave.dataGame.purchasedShiel.Count == 0)
        {
            Destroy(Sheld.gameObject);
        }
        if (currenId != LevelManager.Ins.gameSave.dataGame.currentFullset && LevelManager.Ins.gameSave.dataGame.purchasedFullset.Count != 0)
        {

        }
        //LevelManager.Ins.gameSave.SaveGame();
    }
    public void OnClickElement(int price)
    {
        textPrice.SetText(price.ToString());
        buttonElementBuy.gameObject.SetActive(true);
        buttonElementSellect.gameObject.SetActive(false);
    }
    public void HandleButton(int tab, int id, int price)
    {
        if (currenTab == 0)
        {
            if (LevelManager.Ins.gameSave.dataGame.purchasedHair == null)
            {
                LevelManager.Ins.gameSave.dataGame.purchasedHair = new List<int>();
            }
            if (Hair != null)
            {
                Destroy(Hair.gameObject);
            }
            Hair = Instantiate(cureentElement.prefab, LevelManager.Ins.player.PointHair.transform);
            if (!LevelManager.Ins.gameSave.dataGame.purchasedHair.Contains(id))
            {
                buttonElementBuy.gameObject.SetActive(true);
                buttonElementSellect.gameObject.SetActive(false);
                textPrice.SetText(price.ToString());
            }
            else
            {
                buttonElementSellect.gameObject.SetActive(true);
                buttonElementBuy.gameObject.SetActive(false);
                if (currenId == LevelManager.Ins.gameSave.dataGame.currentHair)
                {
                    buttonElementSellect.gameObject.SetActive(false);
                    buttonElementEquiment.gameObject.SetActive(true);
                }
            }
        }
        else if (currenTab == 1)
        {
            if (LevelManager.Ins.gameSave.dataGame.purchasedShort == null)
            {
                LevelManager.Ins.gameSave.dataGame.purchasedShort = new List<int>();
            }
            LevelManager.Ins.player.meshRenderShort.material = cureentElement.material;
            if (!LevelManager.Ins.gameSave.dataGame.purchasedShort.Contains(id))
            {
                buttonElementBuy.gameObject.SetActive(true);
                buttonElementSellect.gameObject.SetActive(false);
                textPrice.SetText(price.ToString());

            }
            else
            {
                buttonElementSellect.gameObject.SetActive(true);
                buttonElementBuy.gameObject.SetActive(false);
                if (currenId == LevelManager.Ins.gameSave.dataGame.currenShort)
                {
                    buttonElementSellect.gameObject.SetActive(false);
                    buttonElementEquiment.gameObject.SetActive(true);
                }
            }
        }
        else if (currenTab == 2)
        {


            if (LevelManager.Ins.gameSave.dataGame.purchasedShiel == null)
            {
                LevelManager.Ins.gameSave.dataGame.purchasedShiel = new List<int>();
            }

            if (Sheld != null)
            {
                Destroy(Sheld.gameObject);
            }
            Sheld = Instantiate(cureentElement.prefab, LevelManager.Ins.player.PointSheld.transform);
            if (!LevelManager.Ins.gameSave.dataGame.purchasedShiel.Contains(id))
            {
                buttonElementBuy.gameObject.SetActive(true);
                buttonElementSellect.gameObject.SetActive(false);
                textPrice.SetText(price.ToString());

            }
            else
            {
                buttonElementSellect.gameObject.SetActive(true);
                buttonElementBuy.gameObject.SetActive(false);
                if (currenId == LevelManager.Ins.gameSave.dataGame.currentSheiel)
                {
                    buttonElementSellect.gameObject.SetActive(false);
                    buttonElementEquiment.gameObject.SetActive(true);
                }
            }
        }
        else if (currenTab == 3)
        {
            if (LevelManager.Ins.gameSave.dataGame.purchasedFullset == null)
            {
                LevelManager.Ins.gameSave.dataGame.purchasedFullset = new List<int>();
            }
            if (!LevelManager.Ins.gameSave.dataGame.purchasedFullset.Contains(id))
            {
                buttonElementBuy.gameObject.SetActive(true);
                buttonElementSellect.gameObject.SetActive(false);
                textPrice.SetText(price.ToString());
            }
            else
            {
                buttonElementSellect.gameObject.SetActive(true);
                buttonElementBuy.gameObject.SetActive(false);
                if (currenId == LevelManager.Ins.gameSave.dataGame.currentFullset)
                {
                    buttonElementSellect.gameObject.SetActive(false);
                    buttonElementEquiment.gameObject.SetActive(true);
                }
            }
        }

    }
    public void SellectElement()
    {
        if (currenTab == 0)
        {
            buttonElementSellect.gameObject.SetActive(false);
            buttonElementEquiment.gameObject.SetActive(true);
            LevelManager.Ins.gameSave.dataGame.currentHair = currenId;
        }
        else if (currenId == 1)
        {
            buttonElementSellect.gameObject.SetActive(false);
            buttonElementEquiment.gameObject.SetActive(true);
            LevelManager.Ins.gameSave.dataGame.currenShort = currenId;
        }
        else if (currenId == 2)
        {
            buttonElementSellect.gameObject.SetActive(false);
            buttonElementEquiment.gameObject.SetActive(true);
            LevelManager.Ins.gameSave.dataGame.currentSheiel = currenId;
        }
        else if (currenId == 3)
        {
            buttonElementSellect.gameObject.SetActive(false);
            buttonElementEquiment.gameObject.SetActive(true);
            LevelManager.Ins.gameSave.dataGame.currentFullset = currenId - 1;
        }
    }
    public void BuyItem()
    {
        if (LevelManager.Ins.gameSave.dataGame.scoreCoint >= cureentElement.price)
        {
            if (currenTab == 0)
            {
                if (LevelManager.Ins.gameSave.dataGame.purchasedHair == null)
                {
                    LevelManager.Ins.gameSave.dataGame.purchasedHair = new List<int>();
                }
                LevelManager.Ins.gameSave.dataGame.purchasedHair.Add(cureentElement.idIcon);

                LevelManager.Ins.coint -= cureentElement.price;
                textCoint.SetText(LevelManager.Ins.coint.ToString());
                LevelManager.Ins.gameSave.dataGame.scoreCoint = LevelManager.Ins.coint;

                buttonElementEquiment.gameObject.SetActive(true);
                buttonElementBuy.gameObject.SetActive(false);
                cureentElement.isBuy = true;
                back = true;
            }
            else if (currenTab == 1)
            {
                if (LevelManager.Ins.gameSave.dataGame.purchasedShort == null)
                {
                    LevelManager.Ins.gameSave.dataGame.purchasedShort = new List<int>();
                }
                LevelManager.Ins.gameSave.dataGame.purchasedShort.Add(cureentElement.idIcon);

                LevelManager.Ins.coint -= cureentElement.price;
                textCoint.SetText(LevelManager.Ins.coint.ToString());
                LevelManager.Ins.gameSave.dataGame.scoreCoint = LevelManager.Ins.coint;

                buttonElementEquiment.gameObject.SetActive(true);
                buttonElementBuy.gameObject.SetActive(false);
                cureentElement.isBuy = true;
                back = true;

            }
            else if (currenTab == 2)
            {
                if (LevelManager.Ins.gameSave.dataGame.purchasedShiel == null)
                {
                    LevelManager.Ins.gameSave.dataGame.purchasedShiel = new List<int>();
                }
                LevelManager.Ins.gameSave.dataGame.purchasedShiel.Add(cureentElement.idIcon);

                LevelManager.Ins.coint -= cureentElement.price;
                textCoint.SetText(LevelManager.Ins.coint.ToString());
                LevelManager.Ins.gameSave.dataGame.scoreCoint = LevelManager.Ins.coint;

                buttonElementEquiment.gameObject.SetActive(true);
                buttonElementBuy.gameObject.SetActive(false);
                cureentElement.isBuy = true;
                back = true;

            }
            else if (currenTab == 3)
            {
                if (LevelManager.Ins.gameSave.dataGame.purchasedFullset == null)
                {
                    LevelManager.Ins.gameSave.dataGame.purchasedFullset = new List<int>();
                }
                LevelManager.Ins.gameSave.dataGame.purchasedFullset.Add(cureentElement.idIcon);

                LevelManager.Ins.coint -= cureentElement.price;
                textCoint.SetText(LevelManager.Ins.coint.ToString());
                LevelManager.Ins.gameSave.dataGame.scoreCoint = LevelManager.Ins.coint;
                buttonElementEquiment.gameObject.SetActive(true);
                buttonElementBuy.gameObject.SetActive(false);
                cureentElement.isBuy = true;
                back = true;
            }
        }
    }
}
