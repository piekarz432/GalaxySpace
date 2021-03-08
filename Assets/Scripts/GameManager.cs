using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

	private int money=0;

    public Shipe shipe;
    public int Money
	{
		get{return money;}

		set {

			money = Mathf.Max(0, value);
            if (MoneyChanged != null) {
				MoneyChanged.Invoke (money);
			}
		}
	}

    public int Points { get; set; }
 
	public event System.Action<int> MoneyChanged;

    private void Start()
    {
        //Money = 0;
        shipe = FindObjectOfType<Shipe>();
        shipe.ShipDestroyed += () => GameEnded();

    }

    
    void UpdateMoney()
    {
        Shop.instance.coins += Money;
    }

    void GameEnded()
    {
        var point = (FindObjectOfType<AsteroidController>().CurrentSpawnNumber * 10) + Points;
        GameState.setCoins(Money);
        GameState.SetCurrentResault(point);
        FindObjectOfType<ContinuePlay>().Continue();
       // FindObjectOfType<QuestCounter>().CounterQuest();
        UpdateMoney();
        //SceneManager.LoadScene("gameover");
    }
   

    // Use this for initialization
    void Update () {
	}

   


	

}
