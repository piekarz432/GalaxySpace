using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipType { Red, Green, Blue, Yellow,RedUpgrade, GreenUpgrade, BlueUpgrade, YellowUpgrade };

[RequireComponent(typeof(AudioSource))]
public class Ship_Gun : MonoBehaviour, iUpgradable
{

	[SerializeField]
	GameObject Bullet;

    [SerializeField]
    AudioClip ShootClip;

    [SerializeField]
    ShipType shipType;

    [SerializeField]
    BulletType[] BulletTypes;

    float LastShootTime=0f;

    private AudioSource AdSource;

    

    #region iUpgradable


    public int MaxLevel
    {
        get { return BulletTypes.Length - 1; }
    }

    public int CurrentLevel { get; private set; }

    public int UpgradeCost
    {
        get { return CurrentLevel* 50 + 25; }
    }

    public void Upgrade()
    {
        CurrentLevel += 1;
    }

    #endregion



	BulletType BulletType
    {
        get
        {
            return BulletTypes[CurrentLevel];
        }
    }


    // Use this for initialization
    void Start () {
        AdSource = GetComponent<AudioSource>();
        AdSource.clip = ShootClip;
        
    }
	
	// Update is called once per frame
	void Update () {

		if (!Input.GetMouseButton(0))
			return;

		if (!CanShoot ())
			return;

			ShotBullets ();
		LastShootTime = Time.timeSinceLevelLoad;

	}
    private void ShotBullets()
    {
        if (shipType == ShipType.Red)
        {
            if (BulletType.CannonType == CannonType.Single)
            {
                ShootBullet(Vector3.zero + Vector3.up * 0.6f, Vector3.zero);

                Debug.Log(Vector3.up);
            }
            else if (BulletType.CannonType == CannonType.Double)
            {
                ShootBullet(Vector3.left * 0.5f, Vector3.back * 1.7f);
                ShootBullet(Vector3.right * 0.53f, Vector3.forward * 1.7f);
            }
            /*
            else if (BulletType.CannonType == CannonType.Triple)
            {
                ShootBullet(Vector3.zero + Vector3.up * 0.6f, Vector3.zero);
                ShootBullet(Vector3.left * 0.53f, Vector3.forward * 5f);
                ShootBullet(Vector3.right * 0.53f, Vector3.back * 5f);
            }
            */
        }
        if (shipType == ShipType.Green)
        {
            if (BulletType.CannonType == CannonType.Single)
            {
                ShootBullet(Vector3.zero + Vector3.up * 0.3f, Vector3.zero);
            }
            else if (BulletType.CannonType == CannonType.Double)
            {
                ShootBullet(Vector3.zero + Vector3.left *0.07f + Vector3.up * 0.6f, Vector3.zero);
                ShootBullet(Vector3.zero + Vector3.right *0.07f + Vector3.up * 0.6f, Vector3.zero);
            }
            /*
            else if (BulletType.CannonType == CannonType.Triple)
            {
                ShootBullet(Vector3.zero + Vector3.up * 0.6f, Vector3.zero);
                ShootBullet(Vector3.left * 0.53f, Vector3.forward * 5f);
                ShootBullet(Vector3.right * 0.53f, Vector3.back * 5f);
            }
            */
        }

        if (shipType == ShipType.Blue)
        {
            if (BulletType.CannonType == CannonType.Double)
            {
                ShootBullet(Vector3.zero + Vector3.left * 0.21f + Vector3.up * 0.6f, Vector3.zero);
                ShootBullet(Vector3.zero + Vector3.right * 0.21f + Vector3.up * 0.6f, Vector3.zero);
            }
        }

        if (shipType == ShipType.Yellow)
        {
            if (BulletType.CannonType == CannonType.Single)
            {
                ShootBullet(Vector3.zero + Vector3.up * 0.4f, Vector3.zero);
            }
        }

        if (shipType == ShipType.RedUpgrade)
        {
            
            if (BulletType.CannonType == CannonType.Double)
            {
                ShootBullet(Vector3.zero + Vector3.left * 0.22f + Vector3.up * 0.6f, Vector3.zero);
                ShootBullet(Vector3.zero + Vector3.right * 0.22f + Vector3.up * 0.6f, Vector3.zero);
            }
            /*
            else if (BulletType.CannonType == CannonType.Triple)
            {
                ShootBullet(Vector3.zero + Vector3.up * 0.6f, Vector3.zero);
                ShootBullet(Vector3.left * 0.53f, Vector3.forward * 5f);
                ShootBullet(Vector3.right * 0.53f, Vector3.back * 5f);
            }
            */
        }

        if (shipType == ShipType.GreenUpgrade)
        {

            if (BulletType.CannonType == CannonType.Double)
            {
                ShootBullet(Vector3.zero + Vector3.left * 0.3f + Vector3.up * 0.6f, Vector3.zero);
                ShootBullet(Vector3.zero + Vector3.right * 0.3f + Vector3.up * 0.6f, Vector3.zero);
            }
            /*
            else if (BulletType.CannonType == CannonType.Triple)
            {
                ShootBullet(Vector3.zero + Vector3.up * 0.6f, Vector3.zero);
                ShootBullet(Vector3.left * 0.53f, Vector3.forward * 5f);
                ShootBullet(Vector3.right * 0.53f, Vector3.back * 5f);
            }
            */
        }

        if (shipType == ShipType.BlueUpgrade)
        {

            if (BulletType.CannonType == CannonType.Double)
            {
                ShootBullet(Vector3.zero + Vector3.left * 0.27f + Vector3.up * 0.62f, Vector3.zero);
                ShootBullet(Vector3.zero + Vector3.right * 0.27f + Vector3.up * 0.62f, Vector3.zero);
            }
            /*
            else if (BulletType.CannonType == CannonType.Triple)
            {
                ShootBullet(Vector3.zero + Vector3.up * 0.6f, Vector3.zero);
                ShootBullet(Vector3.left * 0.53f, Vector3.forward * 5f);
                ShootBullet(Vector3.right * 0.53f, Vector3.back * 5f);
            }
            */
        }

        if (shipType == ShipType.YellowUpgrade)
        {

            if (BulletType.CannonType == CannonType.Triple)
            {
                ShootBullet(Vector3.zero + Vector3.up * 0.65f, Vector3.zero);
                ShootBullet(Vector3.zero + Vector3.left * 0.65f + Vector3.up * 0.1f, Vector3.zero);
                ShootBullet(Vector3.zero + Vector3.right * 0.65f + Vector3.up * 0.1f, Vector3.zero);
            }
            /*
            else if (BulletType.CannonType == CannonType.Triple)
            {
                ShootBullet(Vector3.zero + Vector3.up * 0.6f, Vector3.zero);
                ShootBullet(Vector3.left * 0.53f, Vector3.forward * 5f);
                ShootBullet(Vector3.right * 0.53f, Vector3.back * 5f);
            }
            */
        }

        AdSource.Play();
	}

	private void ShootBullet(Vector3 postion, Vector3 rotation)
	{
		var bullet = Instantiate (Bullet, transform.position + postion+Vector3.up * 0.1f, Quaternion.Euler (rotation));
        Debug.Log("test" + transform.position );
		bullet.GetComponent<Bullet> ().ConfigureBullet (BulletType);
	}

	public bool CanShoot()
	{
		return (Time.timeSinceLevelLoad - LastShootTime >= BulletType.ShootDuration);
	}  
}
