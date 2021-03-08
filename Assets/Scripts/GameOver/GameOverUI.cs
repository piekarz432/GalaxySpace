using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    Text lastResault;

    [SerializeField]
    Text record;

    [SerializeField]
    Text money;

    [SerializeField]
    string playerName;

    [SerializeField]
    GameObject savePanel;

    [SerializeField]
    InputField inputField;

    private TouchScreenKeyboard keyboard;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.persistentDataPath + "/GameData/");
        
        lastResault.text = GameState.GetLastResault().ToString();
        record.text = GameState.GetRecord().ToString();
        money.text = GameState.getCoins().ToString();

        //Shop.instance.coins += int.Parse(money.text);
    }

    private void ShowSavePanel()
    {
        savePanel.SetActive(true);

        inputField.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

    }

    private void ValueChangeCheck()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        var input = FindObjectOfType<SavePanel>().InputField.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;
    }

    private void SubmitName(string arg0)
    {
        if (FindObjectOfType<SavePanel>().InputField.GetComponent<InputField>().text != "" && FindObjectOfType<SavePanel>().InputField.GetComponent<InputField>().text != "Enter your username...")
        {
            FindObjectOfType<SavePanel>().SaveData.GetComponent<Button>().interactable = true;

            playerName = arg0;

            Player tmpPlayer = new Player(playerName, int.Parse(lastResault.text.ToString()));
            HighScore.instance.players.Add(tmpPlayer);

            savePanel.SetActive(false);

        }

        if (FindObjectOfType<SavePanel>().InputField.GetComponent<InputField>().text == "")
        {
            FindObjectOfType<SavePanel>().SaveData.GetComponent<Button>().interactable =false;
        }

    }


    private void SaveGame()
    {
        PlayerData tmpPlayerData = new PlayerData(HighScore.instance.players, Shop.instance.boughtSip, Shop.instance.coins, Shop.instance.selectedShip);
        BinarySerializer.Save(tmpPlayerData, "playerdata");
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene("MainMenu");
        SaveGame();
    }
}
