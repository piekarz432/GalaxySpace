using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{

    private const string LastResault = "last_resault";
    private const string Record = "Record";
    private const string Coins = "Coins";

    public static void SetCurrentResault(int points)
    {
        PlayerPrefs.SetInt(LastResault, points);

        if(points>GetRecord())
        {
            PlayerPrefs.SetInt(Record, points);
        }
    }

    public static void setCoins(int coins)
    {
        PlayerPrefs.SetInt(Coins, coins);
    }

    public static int GetLastResault()
    {
        return PlayerPrefs.GetInt(LastResault, 0);
    }

    public static int GetRecord()
    {
        return  PlayerPrefs.GetInt(Record, 0);
    }

    public static int getCoins()
    {
        return PlayerPrefs.GetInt(Coins, 0);
    }
}
