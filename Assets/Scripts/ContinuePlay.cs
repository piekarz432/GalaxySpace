using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ContinuePlay : MonoBehaviour
{
    public GameObject Panel;

    bool isActive;

    [SerializeField]
    Slider slider;

    GameManager GameManager;

    [SerializeField]
    Button CostButton;

    [SerializeField]
    int Cost;

    [SerializeField]
    int money;

    private Shop shop;

    private void Awake()
    {
        GameManager = FindObjectOfType<GameManager>();
        GameManager.MoneyChanged += _ => RefreshButton();
        
    }
    private void Start()
    {
        money = Shop.instance.coins;
    }


    public void Continue()
    {
        Time.timeScale = 0;
        FindObjectOfType<Ship_Gun>().enabled = false;
        FindObjectOfType<Movement_Ship>().enabled = false;
        FindObjectOfType<SpawnEnemis>().enabled = false;
        FindObjectOfType<GenerateAsteroids>().enabled = false;

        Panel.SetActive(true);
        
        isActive = true;
    }

    private void Update()
    {
        if(isActive)
        {
            slider.value -= 0.02f;
            if(slider.value==0)
            {
                isActive = false;
                Time.timeScale = 1;
                SceneManager.LoadScene("gameover");
            }
        }

    }

    private void RefreshButton()
    {
        var canUpgrade = CanUpgrade();
        CostButton.enabled = canUpgrade;
        CostButton.interactable = canUpgrade;
        CostButton.GetComponent<Image>().color = canUpgrade ? Color.white : Color.black;
    }

    public bool CanUpgrade()
    {
        return money >= Cost;
    }

    public void ClickButton()
    {
        isActive = false;
        FindObjectOfType<Ship_Gun>().enabled = true;
        FindObjectOfType<SpawnEnemis>().enabled = true;
        FindObjectOfType<GenerateAsteroids>().enabled = true;
        slider.value = slider.maxValue;
        Time.timeScale = 1;
        FindObjectOfType<Movement_Ship>().enabled = true;
        Panel.SetActive(false);
        money -= Cost;

        Shop.instance.coins = money;
    }
}
