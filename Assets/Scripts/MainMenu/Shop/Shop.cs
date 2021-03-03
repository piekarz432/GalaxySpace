using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    #region SIngleton:Shop
    public static Shop instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField]
    public Text coinsUiText;

    public int coins;
    public int selectedShip;

    public List<int> boughtSip;

    public void useBoughtSip(int index)
    {
        boughtSip.Add(index);
    }

    public void useCoins(int amount)
    {
        coins -= amount;
    }

    public bool hasEnoughCoins(int amount)
    {
        return (coins >= amount);
    }
    // Start is called before the first frame update
    void Start()
    {
        updateCoinsUiText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateCoinsUiText()
    {
        coinsUiText.text = coins.ToString();
    }

}
