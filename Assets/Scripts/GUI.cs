using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour {

	[SerializeField]
	Text Counter;

	[SerializeField]
	Text MoneyCounter;

    [SerializeField]
    Button ShieldUpgrade;

    [SerializeField]
    Button GunUpgrade;

    // Use this for initialization
    void Awake () {
        FindObjectOfType<GameManager> ().MoneyChanged += money => {
        MoneyCounter.text = money.ToString ();
        };

        FindObjectOfType<AsteroidController>().AsteroidSpawnStart += waveNumber =>
        StartCoroutine(GuiCoroutine(waveNumber));

       }

    private void Start()
    {
        var shield = FindObjectOfType<ShipShiled>();
        ShieldUpgrade.GetComponent<UpgradeButton>().Configure(shield);
        var gun = FindObjectOfType<Ship_Gun>();
        GunUpgrade.GetComponent<UpgradeButton>().Configure(gun);
    }

    private IEnumerator GuiCoroutine(int waveNumber)
    {
        Counter.gameObject.SetActive(true);
        Counter.text = "Wave: " + waveNumber.ToString();
        yield return new WaitForSeconds(2f);
        Counter.gameObject.SetActive(false);
    }
}
