using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadLevel : MonoBehaviour
{
    public void Load()
    {
         SceneManager.LoadScene("Level");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowWarning()
    {
        //FindObjectOfType<SelectShip>().ShowWarning();
    }

    private void OnApplicationQuit()
    {
        PlayerData tmpPlayerData = new PlayerData(HighScore.instance.players, Shop.instance.boughtSip, Shop.instance.coins, Shop.instance.selectedShip);
        BinarySerializer.Save(tmpPlayerData, "playerdata");
    }


}
