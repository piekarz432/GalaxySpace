using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class Player
{
    public string name;
    public int points;

    public Player()
    {

    }
    
    public Player(string name, int points)
    {
        this.name = name;
        this.points = points;
    }

}

[System.Serializable]public class PlayerData
{
    public List<Player> playersData;
    public List<int> boughtShip;
    public int coins;
    public int selectedShip;

    public PlayerData()
    {

    }

    public PlayerData(List<Player> playersData, List<int> boughtShip, int coins, int selectedShip)
    {
        this.playersData = playersData;
        this.boughtShip = boughtShip;
        this.coins = coins;
        this.selectedShip = selectedShip;
    }
   
}