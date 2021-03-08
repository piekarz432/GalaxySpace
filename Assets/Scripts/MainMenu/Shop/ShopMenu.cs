using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    [System.Serializable] public class ItemShop
    {
        public Sprite image;
        public int price;
        public string name;
        public bool isBought = false;
        public bool isSelected = false;
    }

    [SerializeField]
    private List<ItemShop> shopItemList;
    public List<ItemShop> ShopItemList { get => shopItemList;}

    [SerializeField]
    private GameObject itemTemplate;

    [SerializeField]
    private GameObject shopScrollView;

    [SerializeField]
    private ToggleGroup toggleGroup;

    private GameObject item;
    private Button buyButton;
    private Toggle selectToogle;

    public InstantiateCharacter instantiateCharacter;

    [SerializeField]
    private List<Toggle> toggles;

    

    private void Awake()
    {
    }

    private void Start()
    {
        gameObject.SetActive(false);

        //selectShip = FindObjectOfType<SelectShip>();
        Time.timeScale = 1;
        //tutaj
        if(Shop.instance.selectedShip != -1)
        {
            shopItemList[Shop.instance.selectedShip].isSelected = true;
        }
        
        Shop.instance.coinsUiText = GameObject.Find("Money").GetComponentInChildren<Text>();
        
        CreateShopItem();
        
        Shop.instance.updateCoinsUiText();
    }

    private void Update()
    {
    }

    private void OnShopItemClicked(int itemIndex)
    {
        Debug.Log(itemIndex);

        if(Shop.instance.hasEnoughCoins(shopItemList[itemIndex].price))
        {
            Shop.instance.useCoins(shopItemList[itemIndex].price);
            shopItemList[itemIndex].isBought = true;
            shopItemList[itemIndex].isSelected = true;
            Shop.instance.useBoughtSip(itemIndex);
            shopScrollView.transform.GetChild(itemIndex).GetChild(4).GetComponent<Toggle>().interactable = true;
            shopScrollView.transform.GetChild(itemIndex).GetChild(4).GetComponent<Toggle>().isOn = true;
            shopScrollView.transform.GetChild(itemIndex).GetChild(3).GetComponent<Button>().enabled = false;
            shopScrollView.transform.GetChild(itemIndex).GetChild(3).GetComponent<Image>().color = Color.black;
            Shop.instance.updateCoinsUiText();
        }else
        {
            Debug.Log("You don't have enough money");
        }
    }

    public void OpenShop()
    {
        gameObject.SetActive(true);
    }

    public void ExitShop()
    {
        gameObject.SetActive(false);
        shopScrollView.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -395.0352f);
    } 

    private void CreateShopItem()
    {
        for (int i = 0; i < shopItemList.Count; i++)
        {
            item = Instantiate(itemTemplate, new Vector3(278.1f, -75f, 0), Quaternion.Euler(0, 0, 0), shopScrollView.GetComponent<Transform>());
            item.transform.GetChild(2).GetChild(0).GetComponentInChildren<Image>().sprite = shopItemList[i].image;
            item.GetComponentInChildren<Text>().text = shopItemList[i].name;
            buyButton = item.transform.GetComponentInChildren<Button>();
            selectToogle = item.transform.GetComponentInChildren<Toggle>();
            selectToogle.interactable = shopItemList[i].isBought;
            selectToogle.isOn = shopItemList[i].isSelected;
            selectToogle.group = toggleGroup;
            toggles.Add(shopScrollView.transform.GetChild(i).GetChild(4).GetComponent<Toggle>());
            selectToogle.onValueChanged.AddListener(delegate
            {
                ToggleCallValueChanged();
            });
            buyButton.AddEventListener(i, OnShopItemClicked);
        }

        if(Shop.instance.boughtSip.Count != 0 )
        {
            for(int i = 0; i<Shop.instance.boughtSip.Count; i++)
            {
                shopScrollView.transform.GetChild(i).GetChild(4).GetComponent<Toggle>().interactable = true;
                shopScrollView.transform.GetChild(Shop.instance.boughtSip[i]).GetChild(3).GetComponent<Image>().color = Color.black;
            }
        }
    }

    private void ToggleCallValueChanged()
    {
        for(int i = 0; i < toggles.Count; i++)
        {
            if(toggles[0].isOn)
            {
                Shop.instance.selectedShip = 0;
            }
            else if (toggles[1].isOn)
            {
                Shop.instance.selectedShip = 1;
            }
            else if (toggles[2].isOn)
            {
                Shop.instance.selectedShip = 2;
            }
            else if (toggles[3].isOn)
            {
                Shop.instance.selectedShip = 3;
            }
            else if (toggles[4].isOn)
            {
                Shop.instance.selectedShip = 4;
            }
            else if (toggles[5].isOn)
            {
                Shop.instance.selectedShip = 5;
            }
            else if (toggles[6].isOn)
            {
                Shop.instance.selectedShip = 6;
            }
            else if (toggles[7].isOn)
            {
                Shop.instance.selectedShip = 7;
            }
        }

    }

}
