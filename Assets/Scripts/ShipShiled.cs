using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipShiled : MonoBehaviour, iUpgradable
{

	[SerializeField]
	Sprite[] shielSprite;

    bool Active
    {
        get { return CurrentState> 0; }
    }

    #region iUpgradable
    public int MaxLevel
    {
        get { return shielSprite.Length - 1; }
    }

    public int CurrentLevel { get; private set; }

    public int UpgradeCost
    {
        get { return CurrentLevel*50+100; }
    }

    public void Upgrade()
    {
   
        CurrentLevel += 1;
        Rebuild();
    }

    #endregion



    int currentState = 0;
    public int CurrentState
    {
        get { return currentState; }

        set
        {
            currentState = Mathf.Clamp(value, 0, MaxLevel);
            
            UpdateSprite();
        }

    }

    private void Awake()
    {
        FindObjectOfType<AsteroidController>().AsteroidSpawnStart += _ => Rebuild();
    }
    private void Start()
	{
        Rebuild();
	}

    private void Rebuild()
    {
        CurrentState = CurrentLevel;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.GetComponent<Asteroid>())
            {
                var obj = other.gameObject.GetComponent<Asteroid>();

                if (obj == null)
                {
                    return;
                }

                if (!Active)
                {
                    return;
                }

                CurrentState -= 1;
                Destroy(obj.gameObject);
            }

            if (other.gameObject.tag == "Bullet")
            {
                var obj = other.gameObject.GetComponent<Bullet>();

                if (obj == null)
                {
                    return;
                }

                if (!Active)
                {
                    return;
                }

                CurrentState -= 1;
                Destroy(obj.gameObject);
            }

        }

	private void UpdateSprite()
	{
        GetComponent<SpriteRenderer>().sprite = shielSprite[CurrentState];
	}
 
}
