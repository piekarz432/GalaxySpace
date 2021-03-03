using UnityEngine;

public class LoadDataFromFile: MonoBehaviour
{

    private PlayerData playerData;
    private HighScoreMenu highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore = FindObjectOfType<HighScoreMenu>();

        if (BinarySerializer.HasSaved("playerdata"))
        {
            playerData = BinarySerializer.Load<PlayerData>("playerdata");
            HighScore.instance.players = playerData.playersData;
            Shop.instance.coins = playerData.coins;
            Shop.instance.boughtSip = playerData.boughtShip;
            Shop.instance.updateCoinsUiText();
            highScore.createHighScore();
            
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
