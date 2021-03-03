using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public iUpgradable Upgradable;

    [SerializeField]
    GameObject Shop;

    GameManager GameManager;
    Button Button;

    [SerializeField]
    string Text;
    

    private void Awake()
    {
        GameManager = FindObjectOfType<GameManager>();
        Button = GetComponent<Button>();

        var asteroidCotroller = FindObjectOfType<AsteroidController>();
        asteroidCotroller.AsteroidSpawnStart += _ =>Shop.SetActive(false);
        asteroidCotroller.AsteroidSpawnEnd += _ => Shop.SetActive(true);

        GameManager.MoneyChanged += _ => RefreshButton();
    }

    public void Configure(iUpgradable upgradable)
    {
        Upgradable = upgradable;
        Button.onClick.AddListener(Upgrade);
    }

    private void Upgrade()
    {
        if(!CanUpgrade())
        {
            return;
        }
        GameManager.Money -= Upgradable.UpgradeCost;
        Upgradable.Upgrade();
        RefreshButton();
    }

    private void RefreshButton()
    {
        var canUpgrade = CanUpgrade();

        Button.enabled = canUpgrade;
        Button.GetComponent<Image>().color = canUpgrade ? Color.white : Color.black;

        var textComponent = Button.GetComponentInChildren<Text>();
        //textComponent.text = string.Format("{0}, ({1})", Text, Upgradable.CurrentLevel);

        if(!IsMaxLevel())
        {
            textComponent.text = string.Format("{0}", Upgradable.UpgradeCost);
        }
        PlayerPrefs.SetInt("Money",GameManager.Money);
    }

    private bool CanUpgrade()
    {
        return !IsMaxLevel() && IsMoneyEnough();
    }

    private bool IsMaxLevel()
    {
        return Upgradable.CurrentLevel >= Upgradable.MaxLevel;
    }

    private bool IsMoneyEnough()
    {
        return Upgradable.UpgradeCost <= GameManager.Money;
    }
}
