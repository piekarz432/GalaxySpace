using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCounter : MonoBehaviour
{
    /*
    private int CounterPlay;
    public string counterPlay = "CounterPlay";
    */

    public int CounterDestroyedAsteroids;
    private const string counterDestroyedAsteroids = "CounterDestroyedAsteroids";

    public int CounterDestroyedEnemis;
    private const string counterDestroyedEnemis = "CounterDestroyedEnemis";

    public int CounterDestroyedBoss;
    private const string counterDestroyedBoss = "CounterDestroyedBoss";

    public int CounterMoney;
    private const string counterMoney = "CounterMoney";



    private void Start()
    {

    }

    public void CounterQuest()
    {
        PlayerPrefs.SetInt(counterDestroyedEnemis, CounterDestroyedEnemis);
        PlayerPrefs.SetInt(counterDestroyedAsteroids, CounterDestroyedAsteroids);
    }



}
