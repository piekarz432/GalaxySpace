using UnityEngine;

public class LoadDataFromFile: MonoBehaviour
{

    private PlayerData playerData;
    private HighScoreMenu highScore;
    private ShopMenu shopMenu;

    // Start is called before the first frame update
    void Start()
    {
        highScore = FindObjectOfType<HighScoreMenu>();
        shopMenu = FindObjectOfType<ShopMenu>();

        if (BinarySerializer.HasSaved("playerdata"))
        {
            playerData = BinarySerializer.Load<PlayerData>("playerdata");
            HighScore.instance.players = playerData.playersData;
            Shop.instance.coins = playerData.coins;
            Shop.instance.boughtSip = playerData.boughtShip;
            Shop.instance.selectedShip = playerData.selectedShip;
            Shop.instance.updateCoinsUiText();
            shopMenu.ShopItemList[playerData.selectedShip].isSelected = true;
            highScore.createHighScore();
            //Debug.Log(playerData.coins + " " + playerData.boughtShip + " " + playerData.selectedShip);
            
        }else
        {
            Debug.Log("Nie zapisano danych w pliku");
        }

        Debug.Log(Application.persistentDataPath + "/GameData/");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
