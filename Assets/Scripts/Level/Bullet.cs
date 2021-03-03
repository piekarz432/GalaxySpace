using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CannonType{Single, Double,Triple,Boss}

[System.Serializable]
public class BulletType
{
    public CannonType CannonType;
    public Sprite Image;
	public float ShootDuration;
	public float Speed = 20f;
	public float Power=1f;
}

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PolygonCollider2D))]

public class Bullet : MonoBehaviour {

    [SerializeField]
    public float Power=1f;

	Rigidbody2D rgbody2D;


	public void ConfigureBullet(BulletType bulletType)
	{
		Power = bulletType.Power;
		GetComponent<SpriteRenderer> ().sprite = bulletType.Image;
		GetComponent<Rigidbody2D> ().velocity = transform.rotation * Vector3.up * bulletType.Speed;
	}

    public void ConfigureBulletBoss(BulletType bulletType)
    {
        Power = bulletType.Power;
        GetComponent<SpriteRenderer>().sprite = bulletType.Image;
        GetComponent<Rigidbody2D>().velocity = transform.rotation * Vector3.down * bulletType.Speed;
    }

    public void ConfigureBulletEnemis(BulletType bulletType)
    {
        Power = bulletType.Power;
        GetComponent<SpriteRenderer>().sprite = bulletType.Image;
        GetComponent<Rigidbody2D>().velocity = transform.rotation * Vector3.down * bulletType.Speed;
    }
}
